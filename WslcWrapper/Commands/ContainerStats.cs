namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
/// Usage: wslc container stats [<options>] [<container-id>]
/// </summary>
public partial class ContainerStats : WslcCommand
{
    public string? ContainerID { get; set; }

    public ContainerStats() { }

    [SetsRequiredMembers]
    public ContainerStats(string? containerid = null)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Show all regardless of state.
    /// --all
    /// </summary>
    public bool All { get; set; }

    /// <summary>
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Do not truncate output
    /// --no-trunc
    /// </summary>
    public bool NoTrunc { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "stats");
        args.AddFlag("--all", All);
        args.AddOptional("--format", Format);
        args.AddFlag("--no-trunc", NoTrunc);
        args.AddOptional(ContainerID);
    }

}
