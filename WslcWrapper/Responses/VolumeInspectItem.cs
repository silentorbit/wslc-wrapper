namespace SilentOrbit.WSLC.Responses;

public class VolumeInspectItem : Docker.Volume, IVolumeID
{
    public required IDictionary<string, string> DriverOpts { get; set; }

    string IVolumeID.VolumeID => Name;

    public override string ToString() => Name;
}
