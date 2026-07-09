namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Lists active session(s).
/// Usage: wslc system session list [<options>]
/// </summary>
public partial class SystemSessionList : WslcCommand
{
    public SystemSessionList() { }

    /// <summary>
    /// Show detailed information about the listed sessions.
    /// --verbose
    /// </summary>
    public string? Verbose { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "list");
        args.AddOptional("--verbose", Verbose);
    }

}
