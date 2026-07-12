namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Starts a container.
/// Usage: wslc container start [<options>] <container-id>
/// ]]></summary>
public partial class ContainerStart : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Starts a container.
    /// Usage: wslc container start [<options>] <container-id>
    /// ]]></summary>
    public ContainerStart() { }

    /// <summary><![CDATA[
    /// Starts a container.
    /// Usage: wslc container start [<options>] <container-id>
    /// ]]></summary>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStart(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary><![CDATA[
    /// Attach to stdout/stderr of the container
    /// --attach
    /// ]]></summary>
    public bool Attach { get; set; }

    /// <summary><![CDATA[
    /// Attach to stdin and keep it open
    /// --interactive
    /// ]]></summary>
    public bool Interactive { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "start");
        args.AddFlag("--attach", Attach);
        args.AddFlag("--interactive", Interactive);
        args.Add(ContainerID);
    }

}
