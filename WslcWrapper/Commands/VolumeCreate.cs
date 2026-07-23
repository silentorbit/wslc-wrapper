namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Creates a named volume that can be attached to containers.
/// Usage: wslc volume create [<options>] [<volume-name>]
/// ]]></summary>
public partial class VolumeCreate : WslcCommandString<IVolumeID>
{
    /// <summary>
    /// Volume name
    /// </summary>
    public string? VolumeName { get; set; }

    /// <summary><![CDATA[
    /// Creates a named volume that can be attached to containers.
    /// Usage: wslc volume create [<options>] [<volume-name>]
    /// ]]></summary>
    public VolumeCreate() { }

    /// <summary><![CDATA[
    /// Creates a named volume that can be attached to containers.
    /// Usage: wslc volume create [<options>] [<volume-name>]
    /// ]]></summary>
    /// <param name="volume_name">Volume name</param>
    [SetsRequiredMembers]
    public VolumeCreate(string? volume_name = null)
    {
        this.VolumeName = volume_name;
    }

    /// <summary><![CDATA[
    /// Specify volume driver name, e.g. 'guest' or 'vhd' (default: guest)
    /// --driver
    /// ]]></summary>
    public string? Driver { get; set; }

    /// <summary><![CDATA[
    /// Set driver specific options
    /// --opt
    /// ]]></summary>
    public string? Opt { get; set; }

    /// <summary><![CDATA[
    /// Set metadata on an object
    /// --label
    /// ]]></summary>
    public Dictionary<string, string> Label { get; set; } = [];

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "create");
        args.AddOptional("--driver", Driver);
        args.AddOptional("--opt", Opt);
        args.AddOptional("--label", Label);
        args.AddOptional(VolumeName);
    }

}
