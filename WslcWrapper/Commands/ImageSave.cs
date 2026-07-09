namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Saves images.
/// Usage: wslc image save [<options>] <image>
/// </summary>
public partial class ImageSave : WslcCommand
{
    public required string Image { get; set; }

    public ImageSave() { }

    [SetsRequiredMembers]
    public ImageSave(string image)
    {
        this.Image = image;
    }

    /// <summary>
    /// Path for the saved image
    /// --output
    /// </summary>
    public string? Output { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "save");
        args.AddOptional("--output", Output);
        args.Add(Image);
    }

}
