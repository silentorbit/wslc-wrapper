namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ContainerInspect"/>.<see cref="WslcCommand{T}.RunJson"/>
/// 
/// TODO: Get json structure from https://docs.docker.com/reference/api/engine/version/v1.55/#tag/Container/operation/ContainerInspect
/// </summary>
public class ContainerInspectItem : Docker.ContainerInspectResponse, IContainerID
{
    [JsonIgnore]
    string IContainerID.ContainerID => Id;

    public required Docker.PortMap Ports { get => NetworkSettings.Ports; set => NetworkSettings.Ports = value; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => Name ?? Id;
}
