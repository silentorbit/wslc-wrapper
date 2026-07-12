namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// WSLC is the Windows Subsystem for Linux Container CLI tool. It enables management and interaction with WSL containers from the command line.
/// Usage: wslc  [<command>] [<options>]
/// ]]></summary>
public partial class WslcVersion : WslcCommand
{
    /// <summary><![CDATA[
    /// WSLC is the Windows Subsystem for Linux Container CLI tool. It enables management and interaction with WSL containers from the command line.
    /// Usage: wslc  [<command>] [<options>]
    /// ]]></summary>
    public WslcVersion() { }

    /// <summary><![CDATA[
    /// Show version information for this tool
    /// --version
    /// ]]></summary>
    public string? Version { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange();
        args.AddOptional("--version", Version);
    }

}
