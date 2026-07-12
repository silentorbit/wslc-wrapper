namespace SilentOrbit.WSLC.Commands;

public partial class ContainerStart : WslcCommand
{
    /// <summary><![CDATA[
    /// Starts a container.
    /// Usage: wslc container start [<options>] <container-id>
    /// ]]></summary>
    /// <param name="container">Container</param>
    [SetsRequiredMembers]
    public ContainerStart(ContainerListItem container) : this(container.Id)
    {
    }

}
