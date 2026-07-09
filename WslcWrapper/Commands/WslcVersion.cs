namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// WSLC is the Windows Subsystem for Linux Container CLI tool. It enables management and interaction with WSL containers from the command line.
/// Usage: wslc  [<command>] [<options>]
/// </summary>
public partial class WslcVersion : WslcCommand
{
    public WslcVersion() { }

    /// <summary>
    /// Show version information for this tool
    /// --version
    /// </summary>
    public string? Version { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange();
        args.AddOptional("--version", Version);
    }

}
