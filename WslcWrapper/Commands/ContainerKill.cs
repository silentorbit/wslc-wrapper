namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Kills containers.
/// Usage: wslc container kill [<options>] <container-id>
/// ]]></summary>
public partial class ContainerKill : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary><![CDATA[
    /// Kills containers.
    /// Usage: wslc container kill [<options>] <container-id>
    /// ]]></summary>
    public ContainerKill() { }

    /// <summary><![CDATA[
    /// Kills containers.
    /// Usage: wslc container kill [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container_id">Container ID</param>
    [SetsRequiredMembers]
    public ContainerKill(string container_id)
    {
        this.ContainerID = container_id;
    }

    /// <summary><![CDATA[
    /// Kills containers.
    /// Usage: wslc container kill [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerKill(IContainerID container)
    {
        this.ContainerID = container.ContainerID;
    }

    /// <summary><![CDATA[
    /// Signal to send
    /// --signal
    /// ]]></summary>
    public string? Signal { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "kill");
        args.AddOptional("--signal", Signal);
        args.Add(ContainerID);
    }

}
