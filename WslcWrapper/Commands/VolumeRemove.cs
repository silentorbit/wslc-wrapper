namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes one or more volumes. A volume cannot be removed if it is in use by a container.
/// Usage: wslc volume remove [<options>] <volume-name>
/// ]]></summary>
public partial class VolumeRemove : WslcCommandString<IVolumeID>
{
    /// <summary>
    /// Volume name
    /// </summary>
    public required string VolumeName { get; set; }

    /// <summary><![CDATA[
    /// Removes one or more volumes. A volume cannot be removed if it is in use by a container.
    /// Usage: wslc volume remove [<options>] <volume-name>
    /// ]]></summary>
    public VolumeRemove() { }

    /// <summary><![CDATA[
    /// Removes one or more volumes. A volume cannot be removed if it is in use by a container.
    /// Usage: wslc volume remove [<options>] <volume-name>
    /// ]]></summary>
    /// <param name="volume_name">Volume name</param>
    [SetsRequiredMembers]
    public VolumeRemove(string volume_name)
    {
        this.VolumeName = volume_name;
    }

    /// <summary><![CDATA[
    /// Removes one or more volumes. A volume cannot be removed if it is in use by a container.
    /// Usage: wslc volume remove [<options>] <volume-name>
    /// ]]></summary>
    /// <param name="volume">Volume name</param>
    [SetsRequiredMembers]
    public VolumeRemove(IVolumeID volume)
    {
        this.VolumeName = volume.VolumeID;
    }

    /// <summary><![CDATA[
    /// Do not error if the volume does not exist
    /// --force
    /// ]]></summary>
    public bool Force { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "remove");
        args.AddFlag("--force", Force);
        args.Add(VolumeName);
    }

}
