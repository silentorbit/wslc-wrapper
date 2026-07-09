namespace SilentOrbit.WSLC.Data;

public class NetworkInfo
{
    public required string Driver { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
