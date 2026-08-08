namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="NetworkList"/>
/// </summary>
public class NetworkListItem : UnmappedJsonBase, INetworkID
{
    [JsonIgnore]
    public string SessionID { get; set; } = null!;

    string INetworkID.NetworkID => Name ?? Id;


    public required string Driver { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }

    public override string ToString() => Name ?? Id;
}
