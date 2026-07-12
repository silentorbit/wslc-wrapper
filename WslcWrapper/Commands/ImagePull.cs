namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Pulls images.
/// Usage: wslc image pull [<options>] <image>
/// ]]></summary>
public partial class ImagePull : WslcCommand
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary><![CDATA[
    /// Pulls images.
    /// Usage: wslc image pull [<options>] <image>
    /// ]]></summary>
    public ImagePull() { }

    /// <summary><![CDATA[
    /// Pulls images.
    /// Usage: wslc image pull [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImagePull(string image)
    {
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Pulls images.
    /// Usage: wslc image pull [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImagePull(IImageID image)
    {
        this.Image = image.ImageID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "pull");
        args.Add(Image);
    }

}
