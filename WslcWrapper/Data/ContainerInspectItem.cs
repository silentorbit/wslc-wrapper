namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ContainerInspect"/>.<see cref="WslcCommand{T}.RunJson"/>
/// 
/// TODO: Get json structure from https://docs.docker.com/reference/api/engine/version/v1.55/#tag/Container/operation/ContainerInspect
/// </summary>
public class ContainerInspectItem
{

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
