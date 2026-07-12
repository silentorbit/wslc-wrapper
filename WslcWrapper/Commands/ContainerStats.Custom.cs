namespace SilentOrbit.WSLC.Commands;

public partial class ContainerStats : WslcCommand<List<ContainerStatsItem>>, IFormatJson
{
    /// <summary><![CDATA[
    /// Display a snapshot of a running container's resource usage: CPU, memory, network I/O, block I/O, and PIDs.
    /// Usage: wslc container stats [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStats(ContainerListItem container) : this(container.Id)
    {
    }

}
