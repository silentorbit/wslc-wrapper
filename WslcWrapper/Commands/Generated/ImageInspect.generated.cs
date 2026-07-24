namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Inspect images.
/// Usage: wslc image inspect [<options>] <image>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ImageInspect : WslcCommandJson<List<ImageInspectItem>>
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary><![CDATA[
    /// Inspect images.
    /// Usage: wslc image inspect [<options>] <image>
    /// ]]></summary>
    public ImageInspect() { }

    /// <summary><![CDATA[
    /// Inspect images.
    /// Usage: wslc image inspect [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageInspect(string image)
    {
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Inspect images.
    /// Usage: wslc image inspect [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageInspect(IImageID image)
    {
        this.Image = image.ImageID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "inspect");
        args.Add(Image);
    }

}
