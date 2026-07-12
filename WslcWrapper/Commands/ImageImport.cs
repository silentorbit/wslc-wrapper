namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Imports the contents of a tarball to create a filesystem image. Optionally tag the image with a repository and tag name.
/// Usage: wslc image import [<options>] <file> [<image>]
/// ]]></summary>
public partial class ImageImport : WslcCommand
{
    /// <summary>
    /// File or - to read from stdin
    /// </summary>
    public required string File { get; set; }

    /// <summary>
    /// Image name
    /// </summary>
    public string? Image { get; set; }

    /// <summary><![CDATA[
    /// Imports the contents of a tarball to create a filesystem image. Optionally tag the image with a repository and tag name.
    /// Usage: wslc image import [<options>] <file> [<image>]
    /// ]]></summary>
    public ImageImport() { }

    /// <summary><![CDATA[
    /// Imports the contents of a tarball to create a filesystem image. Optionally tag the image with a repository and tag name.
    /// Usage: wslc image import [<options>] <file> [<image>]
    /// ]]></summary>
    /// <param name="file">File or - to read from stdin</param>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageImport(string file, string? image = null)
    {
        this.File = file;
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Imports the contents of a tarball to create a filesystem image. Optionally tag the image with a repository and tag name.
    /// Usage: wslc image import [<options>] <file> [<image>]
    /// ]]></summary>
    /// <param name="file">File or - to read from stdin</param>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageImport(string file, IImageID image)
    {
        this.File = file;
        this.Image = image.ImageID;
    }

    /// <summary><![CDATA[
    /// Do not truncate output
    /// --no-trunc
    /// ]]></summary>
    public bool NoTrunc { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "import");
        args.AddFlag("--no-trunc", NoTrunc);
        args.Add(File);
        args.AddOptional(Image);
    }

}
