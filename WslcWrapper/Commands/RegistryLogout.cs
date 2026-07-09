namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Log out from a registry. If no server is specified, the default is defined by the session.
/// Usage: wslc registry logout [<options>] [<server>]
/// </summary>
public partial class RegistryLogout : WslcCommand
{
    public string? Server { get; set; }

    public RegistryLogout() { }

    [SetsRequiredMembers]
    public RegistryLogout(string? server = null)
    {
        this.Server = server;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("registry", "logout");
        args.AddOptional(Server);
    }

}
