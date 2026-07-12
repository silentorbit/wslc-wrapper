namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes images.
/// Usage: wslc image remove [<options>] <image>
/// ]]></summary>
public partial class ImageRemove : WslcCommand
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary><![CDATA[
    /// Removes images.
    /// Usage: wslc image remove [<options>] <image>
    /// ]]></summary>
    public ImageRemove() { }

    /// <summary><![CDATA[
    /// Removes images.
    /// Usage: wslc image remove [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageRemove(string image)
    {
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Removes images.
    /// Usage: wslc image remove [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageRemove(IImageID image)
    {
        this.Image = image.ImageID;
    }

    /// <summary><![CDATA[
    /// Delete images even if they are being used
    /// --force
    /// ]]></summary>
    public bool Force { get; set; }

    /// <summary><![CDATA[
    /// Do not delete untagged parents
    /// --no-prune
    /// ]]></summary>
    public bool NoPrune { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "remove");
        args.AddFlag("--force", Force);
        args.AddFlag("--no-prune", NoPrune);
        args.Add(Image);
    }

}
