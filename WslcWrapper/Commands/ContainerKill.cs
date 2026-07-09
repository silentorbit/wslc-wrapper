namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Kills containers.
/// Usage: wslc container kill [<options>] <container-id>
/// </summary>
public partial class ContainerKill : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerKill() { }

    [SetsRequiredMembers]
    public ContainerKill(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Signal to send
    /// --signal
    /// </summary>
    public string? Signal { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "kill");
        args.AddOptional("--signal", Signal);
        args.Add(ContainerID);
    }

}
