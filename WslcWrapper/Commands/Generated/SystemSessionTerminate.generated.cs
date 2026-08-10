#nullable enable
namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Terminates an active session. If no session is specified, the default session will be terminated.
/// Usage: wslc system session terminate [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class SystemSessionTerminate : WslcCommand
{
    /// <summary><![CDATA[
    /// Terminates an active session. If no session is specified, the default session will be terminated.
    /// Usage: wslc system session terminate [<options>]
    /// ]]></summary>
    public SystemSessionTerminate() { }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "terminate");
    }

}
