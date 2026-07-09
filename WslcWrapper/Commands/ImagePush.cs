namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Upload an image to a registry.
/// Usage: wslc image push [<options>] <image>
/// </summary>
public partial class ImagePush : WslcCommand
{
    public required string Image { get; set; }

    public ImagePush() { }

    [SetsRequiredMembers]
    public ImagePush(string image)
    {
        this.Image = image;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "push");
        args.Add(Image);
    }

}
