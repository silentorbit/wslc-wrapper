namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Display detailed information on one or more networks.
/// Usage: wslc network inspect [<options>] <network-name>
/// ]]></summary>
public partial class NetworkInspect : WslcCommandJson<List<NetworkInspectItem>>
{
    /// <summary>
    /// Network name
    /// </summary>
    public required string NetworkName { get; set; }

    /// <summary><![CDATA[
    /// Display detailed information on one or more networks.
    /// Usage: wslc network inspect [<options>] <network-name>
    /// ]]></summary>
    public NetworkInspect() { }

    /// <summary><![CDATA[
    /// Display detailed information on one or more networks.
    /// Usage: wslc network inspect [<options>] <network-name>
    /// ]]></summary>
    /// <param name="network_name">Network name</param>
    [SetsRequiredMembers]
    public NetworkInspect(string network_name)
    {
        this.NetworkName = network_name;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "inspect");
        args.Add(NetworkName);
    }

}
