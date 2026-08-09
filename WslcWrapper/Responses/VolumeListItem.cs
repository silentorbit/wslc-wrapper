namespace SilentOrbit.WSLC.Responses;

public class VolumeListItem : UnmappedJsonBase, IVolumeID
{
    public required string Driver { get; set; }
    public required string Name { get; set; }

    [JsonIgnore]
    string ISessionID.SessionID { get; set; } = null!;

    [JsonIgnore]
    string IVolumeID.VolumeID => Name;

    public override string ToString() => Name;
}
