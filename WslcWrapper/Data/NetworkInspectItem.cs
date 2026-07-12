namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="NetworkInspect"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class NetworkInspectItem
{
    public required string Driver { get; set; }
    public required string Id { get; set; }
    public required bool Internal { get; set; }
    public required Dictionary<string, string> Labels { get; set; }
    public required string Name { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
