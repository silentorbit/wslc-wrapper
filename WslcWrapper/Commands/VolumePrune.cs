namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes all unused anonymous local volumes. If --all is specified, also removes unused named volumes. A volume is considered unused when it is not referenced by any container.
/// Usage: wslc volume prune [<options>]
/// ]]></summary>
public partial class VolumePrune : WslcCommand
{
    /// <summary><![CDATA[
    /// Removes all unused anonymous local volumes. If --all is specified, also removes unused named volumes. A volume is considered unused when it is not referenced by any container.
    /// Usage: wslc volume prune [<options>]
    /// ]]></summary>
    public VolumePrune() { }

    /// <summary><![CDATA[
    /// Remove all unused volumes, not just anonymous ones.
    /// --all
    /// ]]></summary>
    public bool All { get; set; }

    /// <summary><![CDATA[
    /// Filter output based on conditions provided
    /// --filter
    /// ]]></summary>
    public string? Filter { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "prune");
        args.AddFlag("--all", All);
        args.AddOptional("--filter", Filter);
    }

}
