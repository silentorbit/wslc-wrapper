namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Lists containers. By default, only running containers are shown; use --all to include all containers.
/// Usage: wslc container list [<options>]
/// ]]></summary>
public partial class ContainerList : WslcCommand<List<ContainerListItem>>, IFormatJson
{
    /// <summary><![CDATA[
    /// Lists containers. By default, only running containers are shown; use --all to include all containers.
    /// Usage: wslc container list [<options>]
    /// ]]></summary>
    public ContainerList() { }

    /// <summary><![CDATA[
    /// Show all regardless of state.
    /// --all
    /// ]]></summary>
    public bool All { get; set; }

    /// <summary><![CDATA[
    /// Filter output based on conditions provided
    /// --filter
    /// ]]></summary>
    public string? Filter { get; set; }

    /// <summary><![CDATA[
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// ]]></summary>
    public string? Format { get; set; }

    /// <summary><![CDATA[
    /// Show n last created containers (includes all states)
    /// --last
    /// ]]></summary>
    public string? Last { get; set; }

    /// <summary><![CDATA[
    /// Show the latest created container (includes all states)
    /// --latest
    /// ]]></summary>
    public string? Latest { get; set; }

    /// <summary><![CDATA[
    /// Do not truncate output
    /// --no-trunc
    /// ]]></summary>
    public bool NoTrunc { get; set; }

    /// <summary><![CDATA[
    /// Outputs the container IDs only
    /// --quiet
    /// ]]></summary>
    public bool Quiet { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
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
