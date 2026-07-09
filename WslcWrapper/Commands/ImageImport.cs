namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Imports the contents of a tarball to create a filesystem image. Optionally tag the image with a repository and tag name.
/// Usage: wslc image import [<options>] <file> [<image>]
/// </summary>
public partial class ImageImport : WslcCommand
{
    public required string File { get; set; }

    public string? Image { get; set; }

    public ImageImport() { }

    [SetsRequiredMembers]
    public ImageImport(string file, string? image = null)
    {
        this.File = file;
        this.Image = image;
    }

    /// <summary>
    /// Do not truncate output
    /// --no-trunc
    /// </summary>
    public bool NoTrunc { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "import");
        args.AddFlag("--no-trunc", NoTrunc);
        args.Add(File);
        args.AddOptional(Image);
    }

}
