namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Upload an image to a registry.
/// Usage: wslc image push [<options>] <image>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ImagePush : WslcCommand
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary><![CDATA[
    /// Upload an image to a registry.
    /// Usage: wslc image push [<options>] <image>
    /// ]]></summary>
    public ImagePush() { }

    /// <summary><![CDATA[
    /// Upload an image to a registry.
    /// Usage: wslc image push [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImagePush(string image)
    {
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Upload an image to a registry.
    /// Usage: wslc image push [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImagePush(IImageID image)
    {
        this.Image = image.ImageID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "push");
        args.Add(Image);
    }

}
