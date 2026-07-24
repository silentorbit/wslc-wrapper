namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Stops containers.
/// Usage: wslc container stop [<options>] [<container-id>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ContainerStop : WslcCommandString<IContainerID>
{
    /// <summary>
    /// Container ID
    /// </summary>
    public string? ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Stops containers.
    /// Usage: wslc container stop [<options>] [<container-id>]
    /// ]]></summary>
    public ContainerStop() { }

    /// <summary><![CDATA[
    /// Stops containers.
    /// Usage: wslc container stop [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStop(string? container_id = null)
    {
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// Stops containers.
    /// Usage: wslc container stop [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStop(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary><![CDATA[
    /// Signal to send
    /// --signal
    /// ]]></summary>
    public string? Signal { get; set; }

    /// <summary><![CDATA[
    /// Time in seconds to wait before executing (default 5)
    /// --time
    /// ]]></summary>
    public string? Time { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "stop");
        args.AddOptional("--signal", Signal);
        args.AddOptional("--time", Time);
        args.AddOptional(ContainerID);
    }

}
