namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Log in to a registry. If no server is specified, the default is defined by the session.
/// Usage: wslc registry login [<options>] [<server>]
/// </summary>
public partial class RegistryLogin : WslcCommand
{
    public string? Server { get; set; }

    public RegistryLogin() { }

    [SetsRequiredMembers]
    public RegistryLogin(string? server = null)
    {
        this.Server = server;
    }

    /// <summary>
    /// Password or Personal Access Token (PAT)
    /// --password
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Take the Password or Personal Access Token (PAT) from stdin
    /// --password-stdin
    /// </summary>
    public string? PasswordStdin { get; set; }

    /// <summary>
    /// Username
    /// --username
    /// </summary>
    public string? Username { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("registry", "login");
        args.AddOptional("--password", Password);
        args.AddOptional("--password-stdin", PasswordStdin);
        args.AddOptional("--username", Username);
        args.AddOptional(Server);
    }

}
