namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Connects a container to an existing network.
/// Usage: wslc network connect [<options>] <network-name> <container-id>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
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
    /// <param name="network_name">Network name</param>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public NetworkConnect(string network_name, string container_id)
    {
        this.NetworkName = network_name;
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// Connects a container to an existing network.
    /// Usage: wslc network connect [<options>] <network-name> <container-id>
    /// ]]></summary>
    /// <param name="network_name">Network name</param>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public NetworkConnect(string network_name, IContainerID container)
    {
        this.NetworkName = network_name;
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
