#nullable enable
namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Attaches to an active session. If no session ID is provided, the wslc default session will be used.
/// Usage: wslc system session shell [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class SystemSessionShell : WslcCommand
{
    /// <summary><![CDATA[
    /// Attaches to an active session. If no session ID is provided, the wslc default session will be used.
    /// Usage: wslc system session shell [<options>]
    /// ]]></summary>
    public SystemSessionShell() { }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "shell");
    }

}
