namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="Commands.ImageInspect"/>
/// </summary>
public class ImageInspecJson
{

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
