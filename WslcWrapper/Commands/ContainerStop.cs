namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Stops containers.
/// Usage: wslc container stop [<options>] [<container-id>]
/// </summary>
public partial class ContainerStop : WslcCommand
{
    public string? ContainerID { get; set; }

    public ContainerStop() { }

    [SetsRequiredMembers]
    public ContainerStop(string? containerid = null)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Signal to send
    /// --signal
    /// </summary>
    public string? Signal { get; set; }

    /// <summary>
    /// Time in seconds to wait before executing (default 5)
    /// --time
    /// </summary>
    public string? Time { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "stop");
        args.AddOptional("--signal", Signal);
        args.AddOptional("--time", Time);
        args.AddOptional(ContainerID);
    }

}
