namespace SilentOrbit.WSLC.Data;

public class VolumeInspectItem : Docker.Volume
{
    public required IDictionary<string, string> DriverOpts { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => Name;
}
