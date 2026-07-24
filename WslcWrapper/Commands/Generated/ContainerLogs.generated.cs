namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// View logs for a container.
/// Usage: wslc container logs [<options>] <container-id>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ContainerLogs : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// View logs for a container.
    /// Usage: wslc container logs [<options>] <container-id>
    /// ]]></summary>
    public ContainerLogs() { }

    /// <summary><![CDATA[
    /// View logs for a container.
    /// Usage: wslc container logs [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public ContainerLogs(string container_id)
    {
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// View logs for a container.
    /// Usage: wslc container logs [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerLogs(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary><![CDATA[
    /// Follow log output
    /// --follow
    /// ]]></summary>
    public bool Follow { get; set; }

    /// <summary><![CDATA[
    /// Number of lines to show from the end of the logs
    /// --tail
    /// ]]></summary>
    public bool Tail { get; set; }

    /// <summary><![CDATA[
    /// Show timestamps in log output
    /// --timestamps
    /// ]]></summary>
    public bool Timestamps { get; set; }

    /// <summary><![CDATA[
    /// Show logs since timestamp (Unix epoch seconds or RFC3339, e.g. 2024-01-15T10:30:00Z)
    /// --since
    /// ]]></summary>
    public string? Since { get; set; }

    /// <summary><![CDATA[
    /// Show logs before timestamp (Unix epoch seconds or RFC3339, e.g. 2024-01-15T10:30:00Z)
    /// --until
    /// ]]></summary>
    public string? Until { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "logs");
        args.AddFlag("--follow", Follow);
        args.AddFlag("--tail", Tail);
        args.AddFlag("--timestamps", Timestamps);
        args.AddOptional("--since", Since);
        args.AddOptional("--until", Until);
        args.Add(ContainerID);
    }

}
