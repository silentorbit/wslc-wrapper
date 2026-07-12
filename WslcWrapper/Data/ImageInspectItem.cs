namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ImageInspect"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class ImageInspectItem
{

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
