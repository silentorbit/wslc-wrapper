namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes all dangling images. If --all is specified, removes all images not used by any container.
/// Usage: wslc image prune [<options>]
/// </summary>
public partial class ImagePrune : WslcCommand
{
    public ImagePrune() { }

    /// <summary>
    /// Remove all unused images, not just dangling ones.
    /// --all
    /// </summary>
    public bool All { get; set; }

    /// <summary>
    /// Filter output based on conditions provided
    /// --filter
    /// </summary>
    public string? Filter { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "prune");
        args.AddFlag("--all", All);
        args.AddOptional("--filter", Filter);
    }

}
