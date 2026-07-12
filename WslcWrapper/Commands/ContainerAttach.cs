namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Attaches to a container.
/// Usage: wslc container attach [<options>] <container-id>
/// ]]></summary>
public partial class ContainerAttach : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Attaches to a container.
    /// Usage: wslc container attach [<options>] <container-id>
    /// ]]></summary>
    public ContainerAttach() { }

    /// <summary><![CDATA[
    /// Attaches to a container.
    /// Usage: wslc container attach [<options>] <container-id>
    /// ]]></summary>
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public ContainerAttach(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "attach");
        args.Add(ContainerID);
    }

}
