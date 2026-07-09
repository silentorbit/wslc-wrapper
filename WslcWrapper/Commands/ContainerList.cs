namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Lists containers. By default, only running containers are shown; use --all to include all containers.
/// Usage: wslc container list [<options>]
/// </summary>
public partial class ContainerList : WslcCommand<List<ContainerInfo>>
{
    public ContainerList() { }

    /// <summary>
    /// Show all regardless of state.
    /// --all
    /// </summary>
    public bool All { get; set; }

    /// <summary>
    /// Filter output based on conditions provided
    /// --filter
    /// </summary>
    public string? Filter { get; set; }

    /// <summary>
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Show n last created containers (includes all states)
    /// --last
    /// </summary>
    public string? Last { get; set; }

    /// <summary>
    /// Show the latest created container (includes all states)
    /// --latest
    /// </summary>
    public string? Latest { get; set; }

    /// <summary>
    /// Do not truncate output
    /// --no-trunc
    /// </summary>
    public bool NoTrunc { get; set; }

    /// <summary>
    /// Outputs the container IDs only
    /// --quiet
    /// </summary>
    public bool Quiet { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "list");
        args.AddFlag("--all", All);
        args.AddOptional("--filter", Filter);
        args.AddOptional("--format", Format);
        args.AddOptional("--last", Last);
        args.AddOptional("--latest", Latest);
        args.AddFlag("--no-trunc", NoTrunc);
        args.AddFlag("--quiet", Quiet);
    }

}
