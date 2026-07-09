using System.Diagnostics;

namespace SilentOrbit.WSLC.Data;

/// <summary>
/// Directly mapping of wslc json output.
/// Also used in <see cref="CreateCommand"/>
/// </summary>
public class PortMap : IListArg
{
    /// <summary>
    /// Not yet used
    /// </summary>
    public string? BindingAddress { get; set; }
    public required ushort HostPort { get; set; }
    public required ushort ContainerPort { get; set; }
    public Protocol Protocol { get; set; }

    public PortMap() { }

    [SetsRequiredMembers]
    public PortMap(ushort hostPort, ushort containerPort)
    {
        this.HostPort = hostPort;
        this.ContainerPort = containerPort;
    }

    public static implicit operator PortMap(string arg)
    {
        var parts = arg.Split(':');
        switch (parts.Length)
        {
            case 2:
                return new PortMap
                {
                    HostPort = ushort.Parse(parts[0]),
                    ContainerPort = ushort.Parse(parts[1])
                };

            case 3:
                return new PortMap
                {
                    BindingAddress = parts[0],
                    HostPort = ushort.Parse(parts[1]),
                    ContainerPort = ushort.Parse(parts[2])
                };

            default:
                throw new NotImplementedException(arg);
        }
    }

    public static implicit operator string(PortMap map) => map.BuildArg();

    public string BuildArg()
    {
        Debug.Assert(Protocol == Protocol.TCP);
        if (BindingAddress == null)
            return $"{HostPort}:{ContainerPort}";
        else
            return $"{BindingAddress}:{HostPort}:{ContainerPort}";
    }

}
