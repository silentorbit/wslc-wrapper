namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Disconnects a container from an existing network.
/// Usage: wslc network disconnect [<options>] <network-name> <container-id>
/// ]]></summary>
public partial class NetworkDisconnect : WslcCommand
{
    /// <summary>
    /// Network name
    /// </summary>
    public required string NetworkName { get; set; }

    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Disconnects a container from an existing network.
    /// Usage: wslc network disconnect [<options>] <network-name> <container-id>
    /// ]]></summary>
    public NetworkDisconnect() { }

    /// <summary><![CDATA[
    /// Disconnects a container from an existing network.
    /// Usage: wslc network disconnect [<options>] <network-name> <container-id>
    /// ]]></summary>
    /// <param name="networkname">Network name</param>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public NetworkDisconnect(string networkname, string containerid)
    {
        this.NetworkName = networkname;
        this.ContainerID = containerid;
    }

    /// <summary><![CDATA[
    /// Disconnects a container from an existing network.
    /// Usage: wslc network disconnect [<options>] <network-name> <container-id>
    /// ]]></summary>
    /// <param name="networkname">Network name</param>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public NetworkDisconnect(string networkname, IContainerID container)
    {
        this.NetworkName = networkname;
        this.ContainerID = container.ContainerID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "disconnect");
        args.Add(NetworkName);
        args.Add(ContainerID);
    }

}
