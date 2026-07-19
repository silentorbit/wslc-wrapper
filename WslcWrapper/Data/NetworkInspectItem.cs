namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="NetworkInspect"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class NetworkInspectItem : Docker.Network
{
#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => Name ?? Id;
}
