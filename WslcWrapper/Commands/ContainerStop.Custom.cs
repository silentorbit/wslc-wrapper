namespace SilentOrbit.WSLC.Commands;

public partial class ContainerStop : WslcCommand
{
    /// <summary><![CDATA[
    /// Stops containers.
    /// Usage: wslc container stop [<options>] [<container-id>]
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    [SetsRequiredMembers]
    public ContainerStop(ContainerListItem container) : this(container.Id)
    {
    }
}
