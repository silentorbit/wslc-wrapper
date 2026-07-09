namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes images.
/// Usage: wslc image remove [<options>] <image>
/// </summary>
public partial class ImageRemove : WslcCommand
{
    public required string Image { get; set; }

    public ImageRemove() { }

    [SetsRequiredMembers]
    public ImageRemove(string image)
    {
        this.Image = image;
    }

    /// <summary>
    /// Delete images even if they are being used
    /// --force
    /// </summary>
    public bool Force { get; set; }

    /// <summary>
    /// Do not delete untagged parents
    /// --no-prune
    /// </summary>
    public bool NoPrune { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "remove");
        args.AddFlag("--force", Force);
        args.AddFlag("--no-prune", NoPrune);
        args.Add(Image);
    }

}
