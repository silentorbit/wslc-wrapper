namespace SilentOrbit.WSLC.Data;

public abstract class UnmappedJsonBase
{
#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
