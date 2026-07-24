namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Display detailed information on one or more volumes.
/// Usage: wslc volume inspect [<options>] <volume-name>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class VolumeInspect : WslcCommandJson<List<VolumeInspectItem>>
{
    /// <summary>
    /// Volume name
    /// </summary>
    public required string VolumeName { get; set; }

    /// <summary><![CDATA[
    /// Display detailed information on one or more volumes.
    /// Usage: wslc volume inspect [<options>] <volume-name>
    /// ]]></summary>
    public VolumeInspect() { }

    /// <summary><![CDATA[
    /// Display detailed information on one or more volumes.
    /// Usage: wslc volume inspect [<options>] <volume-name>
    /// ]]></summary>
    /// <param name="volume_name">Volume name</param>
    [SetsRequiredMembers]
    public VolumeInspect(string volume_name)
    {
        this.VolumeName = volume_name;
    }

    /// <summary><![CDATA[
    /// Display detailed information on one or more volumes.
    /// Usage: wslc volume inspect [<options>] <volume-name>
    /// ]]></summary>
    /// <param name="volume">Volume name</param>
    [SetsRequiredMembers]
    public VolumeInspect(IVolumeID volume)
    {
        this.VolumeName = volume.VolumeID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "inspect");
        args.Add(VolumeName);
    }

}
