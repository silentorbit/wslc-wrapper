namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes containers.
/// Usage: wslc container remove [<options>] <container-id>
/// ]]></summary>
public partial class ContainerRemove : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Removes containers.
    /// Usage: wslc container remove [<options>] <container-id>
    /// ]]></summary>
    public ContainerRemove() { }

    /// <summary><![CDATA[
    /// Removes containers.
    /// Usage: wslc container remove [<options>] <container-id>
    /// ]]></summary>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public ContainerRemove(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary><![CDATA[
    /// Delete containers even if they are running
    /// --force
    /// ]]></summary>
    public bool Force { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "remove");
        args.AddFlag("--force", Force);
        args.Add(ContainerID);
    }

}
