namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ContainerInspect"/>.<see cref="WslcCommandJson{T}.RunJson"/>
/// 
/// TODO: Get json structure from https://docs.docker.com/reference/api/engine/version/v1.55/#tag/Container/operation/ContainerInspect
/// </summary>
public class ContainerInspectItem : Docker.ContainerInspectResponse, IContainerID
{
    [JsonIgnore]
    string IContainerID.ContainerID => Name ?? Id;

    public required Docker.PortMap Ports { get => NetworkSettings.Ports; set => NetworkSettings.Ports = value; }

    public required IDictionary<string, string> Labels { get; set; }

    public override string ToString() => Name ?? Id;
}
