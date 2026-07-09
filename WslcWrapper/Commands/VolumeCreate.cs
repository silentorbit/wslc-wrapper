namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Creates a named volume that can be attached to containers.
/// Usage: wslc volume create [<options>] [<volume-name>]
/// </summary>
public partial class VolumeCreate : WslcCommand
{
    public string? VolumeName { get; set; }

    public VolumeCreate() { }

    [SetsRequiredMembers]
    public VolumeCreate(string? volumename = null)
    {
        this.VolumeName = volumename;
    }

    /// <summary>
    /// Specify volume driver name, e.g. 'guest' or 'vhd' (default: guest)
    /// --driver
    /// </summary>
    public string? Driver { get; set; }

    /// <summary>
    /// Set driver specific options
    /// --opt
    /// </summary>
    public string? Opt { get; set; }

    /// <summary>
    /// Set metadata on an object
    /// --label
    /// </summary>
    public string? Label { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "create");
        args.AddOptional("--driver", Driver);
        args.AddOptional("--opt", Opt);
        args.AddOptional("--label", Label);
        args.AddOptional(VolumeName);
    }

}
