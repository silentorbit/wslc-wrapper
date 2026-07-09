namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Display detailed information on one or more networks.
/// Usage: wslc network inspect [<options>] <network-name>
/// </summary>
public partial class NetworkInspect : WslcCommand
{
    public required string NetworkName { get; set; }

    public NetworkInspect() { }

    [SetsRequiredMembers]
    public NetworkInspect(string networkname)
    {
        this.NetworkName = networkname;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "inspect");
        args.Add(NetworkName);
    }

}
