namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Log out from a registry. If no server is specified, the default is defined by the session.
/// Usage: wslc registry logout [<options>] [<server>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class RegistryLogout : WslcCommand
{
    /// <summary>
    /// Server
    /// </summary>
    public string? Server { get; set; }

    /// <summary><![CDATA[
    /// Log out from a registry. If no server is specified, the default is defined by the session.
    /// Usage: wslc registry logout [<options>] [<server>]
    /// ]]></summary>
    public RegistryLogout() { }

    /// <summary><![CDATA[
    /// Log out from a registry. If no server is specified, the default is defined by the session.
    /// Usage: wslc registry logout [<options>] [<server>]
    /// ]]></summary>
    /// <param name="server">Server</param>
    [SetsRequiredMembers]
    public RegistryLogout(string? server = null)
    {
        this.Server = server;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("registry", "logout");
        args.AddOptional(Server);
    }

}
