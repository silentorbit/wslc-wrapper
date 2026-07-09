namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes containers.
/// Usage: wslc container remove [<options>] <container-id>
/// </summary>
public partial class ContainerRemove : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerRemove() { }

    [SetsRequiredMembers]
    public ContainerRemove(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Delete containers even if they are running
    /// --force
    /// </summary>
    public bool Force { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "remove");
        args.AddFlag("--force", Force);
        args.Add(ContainerID);
    }

}
