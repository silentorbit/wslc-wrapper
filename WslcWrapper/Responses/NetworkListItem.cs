namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="NetworkList"/>.<see cref="WslcCommandJson{T}.RunJson"/>
/// </summary>
public class NetworkListItem : UnmappedJsonBase
{
    public required string Driver { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }

    public override string ToString() => Name ?? Id;
}
