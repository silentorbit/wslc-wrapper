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
    public Dictionary<string, string> TypeMap { get; set; } = [];
    /// <summary>
    /// Key: Argument or Option name
    /// </summary>
    public Dictionary<string, string> NameMap { get; set; } = [];
    /// <summary>
    /// Key: Command chain: "image list"
    /// Value: TReturn for WslcCommandJson<TReturn>
    /// </summary>
    public Dictionary<string, string> ReturnJsonMap { get; set; } = [];
    /// <summary>
    /// Key: Command chain: "image list"
    /// Value: TReturn for WslcCommandString<TReturn>
    /// </summary>
    public Dictionary<string, string> ReturnStringMap { get; set; } = [];

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

    static readonly JsonSerializerOptions SaveJsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public void Save()
    {
        var json = JsonSerializer.Serialize(this, SaveJsonOptions);
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
        SetCodeNames(cmd);

        var code = new CodeGenerator();

        var baseType = GetBaseType(cmd);
        var formatInterface = (cmd.Options.Any(o => o.Key == "--format")) ? ", IFormatJson" : null;

        code.AppendLine("namespace SilentOrbit.WSLC.Commands;");
        code.AppendLine();
        code.AppendSummary(cmd.Summary);
        code.AppendLine($"public partial class {cmd.ClassName} : {baseType}{formatInterface}");
        code.AppendLine("{");

        //Argument properties
        foreach (var a in cmd.Arguments)
        {
            code.AppendSummary(a.Summary);
            if (a.PropertyType.StartsWith("List<"))
                code.AppendLine($"public {a.PropertyType} {a.PropertyName} {{ get; set; }} = [];");
            else if (a.PropertyType.EndsWith('?'))
                code.AppendLine($"public {a.PropertyType} {a.PropertyName} {{ get; set; }}");
            else
                code.AppendLine($"public required {a.PropertyType} {a.PropertyName} {{ get; set; }}");
            code.AppendLine();
        }

        //Ctor
        //For serialization and setting arguments via intialization properties
        code.AppendSummary(cmd.Summary);
        code.AppendLine($"public {cmd.ClassName}() {{ }}");
        code.AppendLine();
        GenerateCtor(code, cmd, cmd.Arguments);
        GenerateCtor(code, cmd, GetTypedArguments(cmd.Arguments));

        //Options
        foreach (var o in cmd.Options)
        {
            var setNew = o.PropertyType.StartsWith("List<") ? " = [];" : null;

            code.AppendSummary(o.Summary, o.Key);
            code.AppendLine($"public {o.PropertyType} {o.PropertyName} {{ get; set; }}{setNew}");
            code.AppendLine();
        }

        //BuildArgs
        code.AppendSummary("Return arguments for wslc.exe");
        code.AppendLine("protected override void BuildArgs(List<string> args)");
        code.AppendLine("{");
        code.AppendLine($"args.AddRange({string.Join(", ", cmd.Command.Select(c => $@"""{c}"""))});");
        foreach (var o in cmd.Options)
        {
            switch (o.PropertyType)
            {
                case "string":
                    code.AppendLine($"""args.AddRange("{o.Key}", {o.PropertyName});""");
                    break;

                case "bool":
                    code.AppendLine($"""args.AddFlag("{o.Key}", {o.PropertyName});""");
                    break;
                case "int?":
                case "string?":
                    code.AppendLine($"""args.AddOptional("{o.Key}", {o.PropertyName});""");
                    break;
                case "List<string>":
                case "IList<string>":
                    code.AppendLine($"""foreach (var v in {o.PropertyName})""");
                    code.AppendLine($"""args.AddRange("{o.Key}", v);""");
                    break;

                case "List<PortMap>":
                case "List<EnvValue>":
                case "List<VolumeArg>":
                    code.AppendLine($"""args.AddOptional("{o.Key}", {o.PropertyName});""");
                    break;

                default:
                    Debug.Fail(o.PropertyType);
                    throw new NotImplementedException(o.PropertyType);
            }
        }
        foreach (var a in cmd.Arguments)
        {
            switch (a.PropertyType)
            {
                case "IList<string>":
                case "List<string>":
                    code.AppendLine($"args.AddRange({a.PropertyName});");
                    break;
                case "IList<string>?":
                    code.AppendLine($"args.AddOptional({a.PropertyName});");
                    break;
                case "string?":
                    code.AppendLine($"args.AddOptional({a.PropertyName});");
                    break;
                case "string":
                    code.AppendLine($"args.Add({a.PropertyName});");
                    break;

                default:
                    Debug.Fail(a.PropertyType);
                    throw new NotImplementedException(a.PropertyType);
            }
        }

        code.AppendLine("}");
        code.AppendLine();

        code.AppendLine("}");
        return code.ToString();
    }

    private string GetBaseType(CommandData cmd)
    {
        var key = string.Join(" ", cmd.Command);
        string? returnType;

        if (ReturnJsonMap.TryGetValue(key, out returnType))
        {
            Debug.Assert(ReturnStringMap.ContainsKey(key) == false);
            return $"WslcCommandJson<{returnType}>";
        }

        if (ReturnStringMap.TryGetValue(key, out returnType))
        {
            return $"WslcCommandString<{returnType}>";
        }

        return "WslcCommand";
    }

    static void GenerateCtor(CodeGenerator code, CommandData cmd, IEnumerable<Argument> arguments)
    {
        if (arguments.Any() == false)
            return;

        code.AppendSummary(cmd.Summary);
        foreach (var a in arguments)
            code.AppendParam(a.CtorParameterName, a.Summary);

        code.AppendLine("[SetsRequiredMembers]");
        code.AppendLine($"public {cmd.ClassName}({string.Join(", ", CtorArgumentEnum(arguments))})");
        code.AppendLine("{");
        foreach (var a in arguments)
            code.AppendLine($"this.{a.PropertyName} = {a.CtorPropertyValue};");
        code.AppendLine("}");
        code.AppendLine();
    }

    static IEnumerable<Argument> GetTypedArguments(IEnumerable<Argument> args)
    {
        var hasContainerId = args.Any(a => a.Key == "container-id");
        var hasImage = args.Any(a => a.Key == "image");
        if (!hasContainerId && !hasImage)
            yield break;

        foreach (var a in args)
        {
            switch (a.Key)
            {
                case "container-id":
                    yield return new Argument(a.Key, a.Summary)
                    {
                        PropertyType = a.PropertyType,
                        PropertyName = a.PropertyName,
                        CtorParameterName = "container",
                        CtorParameterType = "IContainerID",
                        CtorPropertyValue = "container.ContainerID",
                    };
                    break;
                case "image":
                    yield return new Argument(a.Key, a.Summary)
                    {
                        PropertyType = a.PropertyType,
                        PropertyName = a.PropertyName,
                        CtorParameterName = "image",
                        CtorParameterType = "IImageID",
                        CtorPropertyValue = "image.ImageID",
                    };
                    break;

                default:
                    yield return a;
                    break;
            }
        }
    }

    static IEnumerable<string> CtorArgumentEnum(IEnumerable<Argument> args)
    {
        foreach (var a in args)
        {
            var n = a.CtorParameterName;
            var t = a.CtorParameterType;

            if (t.StartsWith("List<") || t.StartsWith("IList<"))
                yield return $"params {t} {n}";
            else if (t.EndsWith('?'))
                yield return $"{t} {n} = null";
            else
                yield return $"{t} {n}";
        }
    }

    static string ToUppercase(string word)
    {
        return char.ToUpperInvariant(word[0]) + word.Substring(1);
    }

    void SetCodeNames(CommandData cmd)
    {
        foreach (var a in cmd.Arguments)
        {
            a.PropertyType = GetCodeArgumentType(cmd, a);
            a.PropertyName = GetCodePropertyName(a);
            a.CtorParameterType = a.PropertyType;
            a.CtorParameterName = a.PropertyName.ToLowerInvariant();
            a.CtorPropertyValue = a.CtorParameterName;
        }

        foreach (var o in cmd.Options)
        {
            o.PropertyType = GetCodeArgumentType(cmd, o);
            o.PropertyName = GetCodePropertyName(o);
        }
    }

    string GetCodePropertyName(Argument a)
    {
        if (NameMap.TryGetValue(a.Key, out var value))
            return value;

        var parts = a.Key.Trim('-').Split('-');
        var name = string.Concat(parts.Select(ToUppercase));

        NameMap[a.Key] = name;
        return name;
    }

    /// <summary>
    /// Both argument and options
    /// </summary>
    string GetCodeArgumentType(CommandData cmd, Argument a)
    {
        var key = a.Key;

        if (TypeMap.TryGetValue(key, out var value) == false)
        {
            value = TypeMap[key] = "string";
        }

        if (IsTypeNullable(cmd, a))
        {
            //Lists and bool are optional by their nature
            if (key.StartsWith("--") && value.Contains("List"))
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
    static bool IsTypeNullable(CommandData cmd, Argument a)
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

}
