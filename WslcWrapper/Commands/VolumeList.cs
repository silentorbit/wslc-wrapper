namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Lists all volumes in the session.
/// Usage: wslc volume list [<options>]
/// </summary>
public partial class VolumeList : WslcCommand, IFormatJson
{
    public VolumeList() { }

    /// <summary>
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Outputs the volume names only
    /// --quiet
    /// </summary>
    public bool Quiet { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "list");
        args.AddOptional("--format", Format);
        args.AddFlag("--quiet", Quiet);
    }

}
