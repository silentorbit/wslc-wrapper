namespace SilentOrbit.WSLC.Data;

public class VolumeInspectItem
{
    public required string CreatedAt { get; set; }
    public required string Driver { get; set; }
    public required object DriverOpts { get; set; }
    public required Dictionary<string,string> Labels { get; set; }
    public required string Name { get; set; }
    public required object? Status { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
