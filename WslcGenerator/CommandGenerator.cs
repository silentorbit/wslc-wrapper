using SilentOrbit.Disk;
using SilentOrbit.WSLC.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SilentOrbit.WSLC;

class CommandGenerator
{
    /// <summary>
    /// Key: Argument or Option name
    /// </summary>
    public Dictionary<string, string> TypeMap { get; set; } = new();
    /// <summary>
    /// Key: Argument or Option name
    /// </summary>
    public Dictionary<string, string> NameMap { get; set; } = new();
    /// <summary>
    /// Key: Command chain: "image list"
    /// Value: TReturn for WslcArguments<TReturn>
    /// </summary>
    public Dictionary<string, string> ReturnMap { get; set; } = new();

    #region Load/Save Config

    [JsonIgnore]
    FilePath generatorFile = null!;

    DirPath targetDir = null!;

    public static CommandGenerator LoadConfig([CallerFilePath] string sourceFilePath = "")
    {
        var sourceFile = new FilePath(sourceFilePath);
        var file = sourceFile.Parent.CombineFile("CommandGenerator.json");
        CommandGenerator gen;
        if (file.Exists() == false)
        {
            gen = new CommandGenerator();
        }
        else
        {
            var json = file.ReadAllText();
            gen = JsonSerializer.Deserialize<CommandGenerator>(json) ?? new();
        }
        gen.generatorFile = file;
        gen.targetDir = sourceFile.Parent.Parent.CombineDir("WslcWrapper", "Commands");
        return gen;
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        });
        generatorFile.WriteAllText(json);
    }

    #endregion Load/Save Config

    internal FilePath Generate(CommandData cmd)
    {
        var code = GenerateCode(cmd);

        var target = targetDir.CombineFile($"{cmd.ClassName}.cs");
        File.WriteAllText(target.Path, code, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)); //With BOM

        return target;
    }

    string GenerateCode(CommandData cmd)
    {
        var code = new CodeGenerator();

        if (ReturnMap.TryGetValue(string.Join(" ", cmd.Command), out var returnType))
            returnType = $"<{returnType}>";

        code.AppendLine("namespace SilentOrbit.WSLC.Commands;");
        code.AppendLine();
        code.AppendLine("/// <summary>");
        foreach (var summaryLine in cmd.Summary)
            code.AppendLine($"/// {summaryLine}");
        code.AppendLine("/// </summary>");
        code.AppendLine($"public partial class {cmd.ClassName} : WslcCommand{returnType}");
        code.AppendLine("{");

        //Arguments
        foreach (var a in cmd.Arguments)
        {
            var t = GetArgumentType(cmd, a);
            var n = GetPropertyName(a);
            if (t.StartsWith("List<"))
                code.AppendLine($"public {t} {n} {{ get; set; }} = [];");
            else if (t.EndsWith("?"))
                code.AppendLine($"public {t} {n} {{ get; set; }}");
            else
                code.AppendLine($"public required {t} {n} {{ get; set; }}");
            code.AppendLine();
        }

        //Ctor
        //For serialization and setting arguments via intialization properties
        code.AppendLine($"public {cmd.ClassName}() {{ }}");
        code.AppendLine();
        if (cmd.Arguments.Count > 0)
        {
            code.AppendLine("[SetsRequiredMembers]");
            code.AppendLine($"public {cmd.ClassName}({string.Join(", ", CtorArgumentEnum(cmd))})");
            code.AppendLine("{");
            foreach (var a in cmd.Arguments)
            {
                var n = GetPropertyName(a);
                code.AppendLine($"this.{n} = {n.ToLowerInvariant()};");
            }
            code.AppendLine("}");
            code.AppendLine();
        }

        //Options
        foreach (var o in cmd.Options)
        {
            var t = GetArgumentType(cmd, o);
            var n = GetPropertyName(o);
            var setNew = t.StartsWith("List<") ? " = [];" : null;

            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {o.Summary}");
            code.AppendLine($"/// {o.Key}");
            code.AppendLine($"/// </summary>");
            code.AppendLine($"public {t} {n} {{ get; set; }}{setNew}");
            code.AppendLine();
        }

        //BuildArgs
        code.AppendLine("protected override void BuildArgs(List<string> args)");
        code.AppendLine("{");
        code.AppendLine($"args.AddRange({string.Join(", ", cmd.Command.Select(c => $@"""{c}"""))});");
        foreach (var o in cmd.Options)
        {
            var t = GetArgumentType(cmd, o);
            var propertyName = GetPropertyName(o);
            switch (t)
            {
                case "string":
                    code.AppendLine($"""args.AddRange("{o.Key}", {propertyName});""");
                    break;

                case "bool":
                    code.AppendLine($"""args.AddFlag("{o.Key}", {propertyName});""");
                    break;
                case "string?":
                    code.AppendLine($"""args.AddOptional("{o.Key}", {propertyName});""");
                    break;
                case "List<string>":
                case "IList<string>":
                    code.AppendLine($"""foreach (var v in {propertyName})""");
                    code.AppendLine($"""args.AddRange("{o.Key}", v);""");
                    break;

                case "List<PortMap>":
                case "List<EnvValue>":
                case "List<VolumeArg>":
                    code.AppendLine($"""args.AddOptional("{o.Key}", {propertyName});""");
                    break;

                default:
                    Debug.Fail(t);
                    throw new NotImplementedException(t);
            }
        }
        foreach (var a in cmd.Arguments)
        {
            var t = GetArgumentType(cmd, a);
            var propertyName = GetPropertyName(a);
            switch (t)
            {
                case "IList<string>":
                case "List<string>":
                    code.AppendLine($"args.AddRange({propertyName});");
                    break;

                case "string?":
                    code.AppendLine($"args.AddOptional({propertyName});");
                    break;
                case "string":
                    code.AppendLine($"args.Add({propertyName});");
                    break;

                default:
                    Debug.Fail(t);
                    throw new NotImplementedException(t);
            }
        }

        code.AppendLine("}");
        code.AppendLine();

        code.AppendLine("}");
        return code.ToString();
    }

    IEnumerable<string> CtorArgumentEnum(CommandData cmd)
    {
        foreach (var a in cmd.Arguments)
        {
            var n = GetPropertyName(a).ToLowerInvariant();
            var t = GetArgumentType(cmd, a);

            if (t.StartsWith("List<") || t.StartsWith("IList<"))
                yield return $"params {t} {n}";
            else if (t.EndsWith("?"))
                yield return $"{t} {n} = null";
            else
                yield return $"{t} {n}";
        }
    }

    /// <summary>
    /// Both argument and options
    /// </summary>
    string GetArgumentType(CommandData cmd, Argument a)
    {
        var key = a.Key;

        if (TypeMap.TryGetValue(key, out var value) == false)
        {
            value = TypeMap[key] = "string";
        }

        if (IsOptional(cmd, a))
        {
            //Lists and bool are optional by their nature
            if (value.Contains("List"))
                return value;
            if (value == "bool")
                return value;

            return $"{value}?";
        }
        else
        {
            Debug.Assert(value.Contains("List") == false, "Unexpected List type for required argument");
        }

        return value;
    }

    /// <summary>
    /// Determine optional status from <see cref="CommandData.Summary"/> "Usage: "
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    bool IsOptional(CommandData cmd, Argument a)
    {
        //All options are optional
        if (a.Key[0] == '-')
            return true;

        if (cmd.Summary.Any(s =>
        {
            if (s.StartsWith("Usage: ") == false)
                return false;
            return s.Contains($"[<{a.Key}>]") || s.Contains($"[<{a.Key}>...]");
        }))
            return true;

        Debug.Assert(cmd.Summary.Any(s => s.StartsWith("Usage: ") && s.Contains($"<{a.Key}>")),
            "Didn't find argument in Usage: ");
        return false;
    }

    string GetPropertyName(Argument a)
    {
        if (NameMap.TryGetValue(a.Key, out var value))
            return value;

        var parts = a.Key.Trim('-').Split('-');
        var name = string.Concat(parts.Select(ToUppercase));

        NameMap[a.Key] = name;
        return name;
    }

    static string ToUppercase(string word)
    {
        return char.ToUpperInvariant(word[0]) + word.Substring(1);
    }
}
