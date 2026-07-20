namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Stops containers.
/// Usage: wslc container stop [<options>] [<container-id>]
/// ]]></summary>
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
    /// <param name="containerid">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStop(string? containerid = null)
    {
        this.ContainerID = containerid;
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
