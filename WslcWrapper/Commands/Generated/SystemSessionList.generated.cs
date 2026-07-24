namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Lists active session(s).
/// Usage: wslc system session list [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class SystemSessionList : WslcCommand
{
    /// <summary><![CDATA[
    /// Lists active session(s).
    /// Usage: wslc system session list [<options>]
    /// ]]></summary>
    public SystemSessionList() { }

    /// <summary><![CDATA[
    /// Show detailed information about the listed sessions.
    /// --verbose
    /// ]]></summary>
    public string? Verbose { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "list");
        args.AddOptional("--verbose", Verbose);
    }

}
