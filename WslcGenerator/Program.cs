namespace SilentOrbit.WSLC;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var generator = CommandGenerator.LoadConfig();
        Scan([], generator);
        generator.Save();
    }

    static void Scan(string[] args, CommandGenerator generator)
    {
        Console.WriteLine($"wslc.exe {string.Join(",", args)}");
        var output = WslcExe.Run([.. args, "-?"]);
        var cmd = Parser.Parse(args, output);
        Console.WriteLine($"Parsed: {cmd}");

        if (cmd.Arguments.Count > 0 || cmd.Options.Count > 0 || cmd.SubCommands.Count == 0)
        {
            if (generator.IsAlias(args) == false)
            {
                var path = generator.Generate(cmd);
                Console.WriteLine($"Saved: {path}");
            }
        }

        foreach (var sub in cmd.SubCommands)
        {
            Scan([.. args, sub], generator);
        }
    }
}
