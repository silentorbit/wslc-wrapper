using SilentOrbit.WSLC.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SilentOrbit.WSLC;

/// <summary>
/// Pars
/// </summary>
static class Parser
{
    public static CommandData Parse(IList<string> args, string output)
    {
        var cmd = new CommandData()
        {
            Command = args.ToList(),
        };
        
        var reader = new LineReader(output);

        reader.ExpectLine("Copyright (c) Microsoft Corporation. All rights reserved.");
        reader.ExpectLine("For privacy information about this product please visit https://aka.ms/privacy.");
        reader.ExpectLine();
        cmd.Summary = reader.ReadLines().ToList();
        var usage = reader.ReadLine();
        Debug.Assert(usage.StartsWith("Usage: "));
        cmd.Summary.Add(usage);

        reader.ExpectLine();

        var line = reader.ReadLine();

        //Skip command aliases
        if (line.StartsWith("The following command aliases are available: "))
        {
            reader.ExpectLine();
            line = reader.ReadLine();
        }

        while (true)
        {
            switch (line)
            {
                case "The following commands are available:":
                case "The following sub-commands are available:":
                    cmd.SubCommands = ParseSubCommands(reader);
                    break;

                case "The following arguments are available:":
                    cmd.Arguments = ParseArguments(reader);
                    break;

                case "The following options are available:":
                    cmd.Options = ParseOptions(reader);
                    break;

                case "":
                    reader.ExpectEnd();
                    return cmd;

                default:
                    throw new NotImplementedException(line);
            }
            line = reader.ReadLine();
        }
    }

    static List<string> ParseSubCommands(LineReader reader)
    {
        var subCmd = new List<string>();

        var re = new Regex(@"^  ([a-z\-]+) +.*$");
        while (true)
        {
            var line = reader.ReadLine();
            if (line == "")
            {
                reader.ExpectLine("For more details on a specific command, pass it the help argument. [-?]");
                reader.ExpectLine();
                return subCmd;
            }

            var m = re.Match(line);
            Debug.Assert(m.Success);
            if (m.Success == false)
                throw new Exception();
            subCmd.Add(m.Groups[1].Value);
        }
    }

    static List<Argument> ParseArguments(LineReader reader)
    {
        var args = new List<Argument>();

        var re = new Regex(@"^  ([a-z\-]+) +(.*)$");
        while (true)
        {
            var line = reader.ReadLine();
            if (line == "")
                return args;

            var m = re.Match(line);
            Debug.Assert(m.Success);
            if (m.Success == false)
                throw new Exception();
            args.Add(new(m.Groups[1].Value, m.Groups[2].Value));
        }
    }

    static List<Argument> ParseOptions(LineReader reader)
    {
        var ops = new List<Argument>();

        var re = new Regex(@"^  ((-[a-zA-Z],)?(--[a-z\-]+)) +(.*)$");
        while (true)
        {
            var line = reader.ReadLine();
            if (line.StartsWith("  -?,--help"))
            {
                reader.ExpectLine();
                return ops;
            }
            if (line == "")
                throw new Exception();

            var m = re.Match(line);
            Debug.Assert(m.Success);
            if (m.Success == false)
                throw new Exception();
            ops.Add(new(m.Groups[3].Value, m.Groups[4].Value));
        }
    }

    static readonly string[] toRemove = [
        "For more details on a specific command, pass it the help argument. [-?]",
        "-?,--help  Shows help about the selected command",
    ];
    static readonly Regex[] toRemoveRegex = [
        //new(@"^Usage: wslc .*$", RegexOptions.Multiline),
        new(@"^The following command aliases are available: .*$", RegexOptions.Multiline),
        new(@"^ *-\?,--help +Shows help about the selected command$", RegexOptions.Multiline),
    ];

}
