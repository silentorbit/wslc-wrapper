namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Loads images.
/// Usage: wslc image load [<options>]
/// </summary>
public partial class ImageLoad : WslcCommand
{
    public ImageLoad() { }

    /// <summary>
    /// Provides path to the tar archive file containing the image
    /// --input
    /// </summary>
    public string? Input { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "load");
        args.AddOptional("--input", Input);
    }

}
