namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes one or more networks.
/// Usage: wslc network remove [<options>] <network-name>
/// ]]></summary>
public partial class NetworkRemove : WslcCommand
{
    /// <summary>
    /// Network name
    /// </summary>
    public required string NetworkName { get; set; }

    /// <summary><![CDATA[
    /// Removes one or more networks.
    /// Usage: wslc network remove [<options>] <network-name>
    /// ]]></summary>
    public NetworkRemove() { }

    /// <summary><![CDATA[
    /// Removes one or more networks.
    /// Usage: wslc network remove [<options>] <network-name>
    /// ]]></summary>
    /// <param name="network_name">Network name</param>
    [SetsRequiredMembers]
    public NetworkRemove(string network_name)
    {
        this.NetworkName = network_name;
    }

    /// <summary><![CDATA[
    /// Do not error if the network does not exist
    /// --force
    /// ]]></summary>
    public bool Force { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "remove");
        args.AddFlag("--force", Force);
        args.Add(NetworkName);
    }

}
