namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Saves images.
/// Usage: wslc image save [<options>] <image>
/// ]]></summary>
public partial class ImageSave : WslcCommand
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary><![CDATA[
    /// Saves images.
    /// Usage: wslc image save [<options>] <image>
    /// ]]></summary>
    public ImageSave() { }

    /// <summary><![CDATA[
    /// Saves images.
    /// Usage: wslc image save [<options>] <image>
    /// ]]></summary>
    /// <param name="image">Image name</param>
    [SetsRequiredMembers]
    public ImageSave(string image)
    {
        this.Image = image;
    }

    /// <summary><![CDATA[
    /// Path for the saved image
    /// --output
    /// ]]></summary>
    public string? Output { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "save");
        args.AddOptional("--output", Output);
        args.Add(Image);
    }

}
