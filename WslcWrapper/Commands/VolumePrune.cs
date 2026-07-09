namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes all unused anonymous local volumes. If --all is specified, also removes unused named volumes. A volume is considered unused when it is not referenced by any container.
/// Usage: wslc volume prune [<options>]
/// </summary>
public partial class VolumePrune : WslcCommand
{
    public VolumePrune() { }

    /// <summary>
    /// Remove all unused volumes, not just anonymous ones.
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
        args.AddRange("volume", "prune");
        args.AddFlag("--all", All);
        args.AddOptional("--filter", Filter);
    }

}
