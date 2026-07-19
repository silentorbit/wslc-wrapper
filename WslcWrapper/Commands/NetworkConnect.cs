namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Connects a container to an existing network.
/// Usage: wslc network connect [<options>] <network-name> <container-id>
/// ]]></summary>
public partial class NetworkConnect : WslcCommand
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
    /// Connects a container to an existing network.
    /// Usage: wslc network connect [<options>] <network-name> <container-id>
    /// ]]></summary>
    public NetworkConnect() { }

    /// <summary><![CDATA[
    /// Connects a container to an existing network.
    /// Usage: wslc network connect [<options>] <network-name> <container-id>
    /// ]]></summary>
    /// <param name="networkname">Network name</param>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public NetworkConnect(string networkname, string containerid)
    {
        this.NetworkName = networkname;
        this.ContainerID = containerid;
    }

    /// <summary><![CDATA[
    /// Connects a container to an existing network.
    /// Usage: wslc network connect [<options>] <network-name> <container-id>
    /// ]]></summary>
    /// <param name="networkname">Network name</param>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public NetworkConnect(string networkname, IContainerID container)
    {
        this.NetworkName = networkname;
        this.ContainerID = container.ContainerID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "connect");
        args.Add(NetworkName);
        args.Add(ContainerID);
    }

}
