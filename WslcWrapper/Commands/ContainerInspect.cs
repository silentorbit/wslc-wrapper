namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Display detailed information about a container.
/// Usage: wslc container inspect [<options>] <container-id>
/// ]]></summary>
public partial class ContainerInspect : WslcCommand<List<ContainerInspectItem>>
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Display detailed information about a container.
    /// Usage: wslc container inspect [<options>] <container-id>
    /// ]]></summary>
    public ContainerInspect() { }

    /// <summary><![CDATA[
    /// Display detailed information about a container.
    /// Usage: wslc container inspect [<options>] <container-id>
    /// ]]></summary>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public ContainerInspect(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary><![CDATA[
    /// Display detailed information about a container.
    /// Usage: wslc container inspect [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerInspect(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "inspect");
        args.Add(ContainerID);
    }

}
