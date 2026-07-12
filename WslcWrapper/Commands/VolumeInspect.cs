namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Display detailed information on one or more volumes.
/// Usage: wslc volume inspect [<options>] <volume-name>
/// ]]></summary>
public partial class VolumeInspect : WslcCommand<List<VolumeInspectItem>>
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
    /// <param name="volumename">Volume name</param>
    [SetsRequiredMembers]
    public VolumeInspect(string volumename)
    {
        this.VolumeName = volumename;
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
