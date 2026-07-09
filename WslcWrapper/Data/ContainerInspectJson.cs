namespace SilentOrbit.WSLC.Data;

/// <summary>
/// https://docs.docker.com/reference/api/engine/version/v1.55/#tag/Container/operation/ContainerInspect
/// </summary>
public class ContainerInspectJson
{

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
