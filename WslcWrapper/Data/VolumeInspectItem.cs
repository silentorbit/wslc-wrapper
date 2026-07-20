namespace SilentOrbit.WSLC.Data;

public class VolumeInspectItem : Docker.Volume
{
    public required IDictionary<string, string> DriverOpts { get; set; }

    public override string ToString() => Name;
}
