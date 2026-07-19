namespace SilentOrbit.WSLC.Data;

public class VolumeListItem
{
    public required string Driver { get; set; }
    public required string Name { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => Name;
}
