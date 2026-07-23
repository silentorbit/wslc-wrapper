namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
/// Usage: wslc container stats [<options>] [<container-id>]
/// ]]></summary>
public partial class ContainerStats : WslcCommandJson<List<ContainerStatsItem>>, IFormatJson
{
    /// <summary>
    /// Container ID
    /// </summary>
    public string? ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
    /// Usage: wslc container stats [<options>] [<container-id>]
    /// ]]></summary>
    public ContainerStats() { }

    /// <summary><![CDATA[
    /// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
    /// Usage: wslc container stats [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStats(string? container_id = null)
    {
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
    /// Usage: wslc container stats [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStats(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary><![CDATA[
    /// Show all regardless of state.
    /// --all
    /// ]]></summary>
    public bool All { get; set; }

    /// <summary><![CDATA[
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// ]]></summary>
    public string? Format { get; set; }

    /// <summary><![CDATA[
    /// Do not truncate output
    /// --no-trunc
    /// ]]></summary>
    public bool NoTrunc { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "stats");
        args.AddFlag("--all", All);
        args.AddOptional("--format", Format);
        args.AddFlag("--no-trunc", NoTrunc);
        args.AddOptional(ContainerID);
    }

}
