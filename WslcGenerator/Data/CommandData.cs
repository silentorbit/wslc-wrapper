#nullable disable
namespace SilentOrbit.WSLC.Data;

internal class CommandData
{
    public List<string> Command { get; set; } = new();

    public List<string> SubCommands { get; set; } = new();

    public List<string> Summary { get; set; }

    public List<Argument> Arguments { get; set; } = new();
    public List<Argument> Options { get; set; } = new();

    public string ClassName
    {
        get
        {
            if (Command.Count == 0)
                return "WslcVersion";

            return string.Concat(Command.Select(w => char.ToUpper(w[0]) + w.Substring(1)));
        }
    } 

    public override string ToString() => ClassName;
}
