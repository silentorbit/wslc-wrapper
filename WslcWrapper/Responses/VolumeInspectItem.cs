namespace SilentOrbit.WSLC.Responses;

public class VolumeInspectItem : Docker.Volume, IVolumeID
{
    public required IDictionary<string, string> DriverOpts { get; set; }

    [JsonIgnore]
    string? ISessionID.Session { get; set; }

    [JsonIgnore]
    string IVolumeID.VolumeID => Name;

    public override string ToString() => Name;
}
