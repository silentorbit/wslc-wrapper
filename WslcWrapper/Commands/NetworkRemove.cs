namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes one or more networks.
/// Usage: wslc network remove [<options>] <network-name>
/// </summary>
public partial class NetworkRemove : WslcCommand
{
    public required string NetworkName { get; set; }

    public NetworkRemove() { }

    [SetsRequiredMembers]
    public NetworkRemove(string networkname)
    {
        this.NetworkName = networkname;
    }

    /// <summary>
    /// Do not error if the network does not exist
    /// --force
    /// </summary>
    public bool Force { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "remove");
        args.AddFlag("--force", Force);
        args.Add(NetworkName);
    }

}
