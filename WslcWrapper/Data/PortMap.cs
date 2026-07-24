using System.Diagnostics;

namespace SilentOrbit.WSLC.Data;

/// <summary>
/// Used in both arguments and response.
/// <see cref="ContainerCreate.Publish"/>
/// <see cref="ContainerRun.Publish"/>
/// <see cref="ContainerListItem.Ports"/>
/// </summary>
public class PortMap : IListArg
{
    public string? BindingAddress { get; set; }
    public required ushort HostPort { get; set; }
    public required ushort ContainerPort { get; set; }
    public Protocol Protocol { get; set; } = Protocol.TCP;

    public PortMap() { }

    [SetsRequiredMembers]
    public PortMap(ushort hostPort, ushort containerPort)
    {
        this.HostPort = hostPort;
        this.ContainerPort = containerPort;
    }

    public string BuildArg()
    {
        Debug.Assert(Protocol == Protocol.TCP);
        if (BindingAddress == null)
            return $"{HostPort}:{ContainerPort}";
        else
            return $"{BindingAddress}:{HostPort}:{ContainerPort}";
    }

    public override string ToString() => BuildArg();
}
