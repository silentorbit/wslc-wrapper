namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Starts a container.
/// Usage: wslc container start [<options>] <container-id>
/// </summary>
public partial class ContainerStart : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerStart() { }

    [SetsRequiredMembers]
    public ContainerStart(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Attach to stdout/stderr of the container
    /// --attach
    /// </summary>
    public bool Attach { get; set; }

    /// <summary>
    /// Attach to stdin and keep it open
    /// --interactive
    /// </summary>
    public bool Interactive { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "start");
        args.AddFlag("--attach", Attach);
        args.AddFlag("--interactive", Interactive);
        args.Add(ContainerID);
    }

}
