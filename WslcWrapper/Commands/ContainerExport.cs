namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Exports a container's filesystem as a tar archive.
/// Usage: wslc container export [<options>] <container-id>
/// ]]></summary>
public partial class ContainerExport : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Exports a container's filesystem as a tar archive.
    /// Usage: wslc container export [<options>] <container-id>
    /// ]]></summary>
    public ContainerExport() { }

    /// <summary><![CDATA[
    /// Exports a container's filesystem as a tar archive.
    /// Usage: wslc container export [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public ContainerExport(string container_id)
    {
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// Exports a container's filesystem as a tar archive.
    /// Usage: wslc container export [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerExport(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary><![CDATA[
    /// Write to a file, instead of STDOUT
    /// --output
    /// ]]></summary>
    public string? Output { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "export");
        args.AddOptional("--output", Output);
        args.Add(ContainerID);
    }

}
