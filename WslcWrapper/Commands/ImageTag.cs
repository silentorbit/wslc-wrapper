namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Tags an image.
/// Usage: wslc image tag [<options>] <source> <target>
/// </summary>
public partial class ImageTag : WslcCommand
{
    public required string Source { get; set; }

    public required string Target { get; set; }

    public ImageTag() { }

    [SetsRequiredMembers]
    public ImageTag(string source, string target)
    {
        this.Source = source;
        this.Target = target;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "tag");
        args.Add(Source);
        args.Add(Target);
    }

}
