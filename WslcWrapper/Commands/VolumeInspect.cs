namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Display detailed information on one or more volumes.
/// Usage: wslc volume inspect [<options>] <volume-name>
/// </summary>
public partial class VolumeInspect : WslcCommand
{
    public required string VolumeName { get; set; }

    public VolumeInspect() { }

    [SetsRequiredMembers]
    public VolumeInspect(string volumename)
    {
        this.VolumeName = volumename;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "inspect");
        args.Add(VolumeName);
    }

}
