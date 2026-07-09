namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes one or more volumes. A volume cannot be removed if it is in use by a container.
/// Usage: wslc volume remove [<options>] <volume-name>
/// </summary>
public partial class VolumeRemove : WslcCommand
{
    public required string VolumeName { get; set; }

    public VolumeRemove() { }

    [SetsRequiredMembers]
    public VolumeRemove(string volumename)
    {
        this.VolumeName = volumename;
    }

    /// <summary>
    /// Do not error if the volume does not exist
    /// --force
    /// </summary>
    public bool Force { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "remove");
        args.AddFlag("--force", Force);
        args.Add(VolumeName);
    }

}
