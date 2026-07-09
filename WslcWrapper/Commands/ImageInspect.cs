namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Inspect images.
/// Usage: wslc image inspect [<options>] <image>
/// </summary>
public partial class ImageInspect : WslcCommand
{
    public required string Image { get; set; }

    public ImageInspect() { }

    [SetsRequiredMembers]
    public ImageInspect(string image)
    {
        this.Image = image;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "inspect");
        args.Add(Image);
    }

}
