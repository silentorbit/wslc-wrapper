namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="NetworkList"/>.<see cref="WslcCommandJson{T}.RunJson"/>
/// </summary>
public class NetworkListItem
{
    public required string Driver { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => Name ?? Id;
}
