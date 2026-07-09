namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Lists images.
/// Usage: wslc image list [<options>]
/// </summary>
public partial class ImageList : WslcCommand<List<ImageInfo>>
{
    public ImageList() { }

    /// <summary>
    /// Filter output based on conditions provided
    /// --filter
    /// </summary>
    public string? Filter { get; set; }

    /// <summary>
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Do not truncate output
    /// --no-trunc
    /// </summary>
    public bool NoTrunc { get; set; }

    /// <summary>
    /// Outputs the container IDs only
    /// --quiet
    /// </summary>
    public bool Quiet { get; set; }

    /// <summary>
    /// Output verbose details
    /// --verbose
    /// </summary>
    public string? Verbose { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "list");
        args.AddOptional("--filter", Filter);
        args.AddOptional("--format", Format);
        args.AddFlag("--no-trunc", NoTrunc);
        args.AddFlag("--quiet", Quiet);
        args.AddOptional("--verbose", Verbose);
    }

}
