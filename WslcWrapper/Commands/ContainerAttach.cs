namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Attaches to a container.
/// Usage: wslc container attach [<options>] <container-id>
/// </summary>
public partial class ContainerAttach : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerAttach() { }

    [SetsRequiredMembers]
    public ContainerAttach(string containerid)
    {
        this.ContainerID = containerid;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "attach");
        args.Add(ContainerID);
    }

}
