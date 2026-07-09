namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Display detailed information about a container.
/// Usage: wslc container inspect [<options>] <container-id>
/// </summary>
public partial class ContainerInspect : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerInspect() { }

    [SetsRequiredMembers]
    public ContainerInspect(string containerid)
    {
        this.ContainerID = containerid;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "inspect");
        args.Add(ContainerID);
    }

}
