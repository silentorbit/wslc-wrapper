namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Log in to a registry. If no server is specified, the default is defined by the session.
/// Usage: wslc registry login [<options>] [<server>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class RegistryLogin : WslcCommand
{
    /// <summary>
    /// Server
    /// </summary>
    public string? Server { get; set; }

    /// <summary><![CDATA[
    /// Log in to a registry. If no server is specified, the default is defined by the session.
    /// Usage: wslc registry login [<options>] [<server>]
    /// ]]></summary>
    public RegistryLogin() { }

    /// <summary><![CDATA[
    /// Log in to a registry. If no server is specified, the default is defined by the session.
    /// Usage: wslc registry login [<options>] [<server>]
    /// ]]></summary>
    /// <param name="server">Server</param>
    [SetsRequiredMembers]
    public RegistryLogin(string? server = null)
    {
        this.Server = server;
    }

    /// <summary><![CDATA[
    /// Password or Personal Access Token (PAT)
    /// --password
    /// ]]></summary>
    public string? Password { get; set; }

    /// <summary><![CDATA[
    /// Take the Password or Personal Access Token (PAT) from stdin
    /// --password-stdin
    /// ]]></summary>
    public string? PasswordStdin { get; set; }

    /// <summary><![CDATA[
    /// Username
    /// --username
    /// ]]></summary>
    public string? Username { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("registry", "login");
        args.AddOptional("--password", Password);
        args.AddOptional("--password-stdin", PasswordStdin);
        args.AddOptional("--username", Username);
        args.AddOptional(Server);
    }

}
