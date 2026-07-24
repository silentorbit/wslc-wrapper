namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Tags an image.
/// Usage: wslc image tag [<options>] <source> <target>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ImageTag : WslcCommand
{
    /// <summary>
    /// Current or existing image reference in the image-name[:tag] format
    /// </summary>
    public required string Source { get; set; }

    /// <summary>
    /// New image reference in the image-name[:tag] format
    /// </summary>
    public required string Target { get; set; }

    /// <summary><![CDATA[
    /// Tags an image.
    /// Usage: wslc image tag [<options>] <source> <target>
    /// ]]></summary>
    public ImageTag() { }

    /// <summary><![CDATA[
    /// Tags an image.
    /// Usage: wslc image tag [<options>] <source> <target>
    /// ]]></summary>
    /// <param name="source">Current or existing image reference in the image-name[:tag] format</param>
    /// <param name="target">New image reference in the image-name[:tag] format</param>
    [SetsRequiredMembers]
    public ImageTag(string source, string target)
    {
        this.Source = source;
        this.Target = target;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "tag");
        args.Add(Source);
        args.Add(Target);
    }

}
