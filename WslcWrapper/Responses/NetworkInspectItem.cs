namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="NetworkInspect"/>
/// </summary>
public class NetworkInspectItem : Docker.Network
{
    public override string ToString() => Name ?? Id;
}
