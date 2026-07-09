namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Pulls images.
/// Usage: wslc image pull [<options>] <image>
/// </summary>
public partial class ImagePull : WslcCommand
{
    public required string Image { get; set; }

    public ImagePull() { }

    [SetsRequiredMembers]
    public ImagePull(string image)
    {
        this.Image = image;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "pull");
        args.Add(Image);
    }

}
