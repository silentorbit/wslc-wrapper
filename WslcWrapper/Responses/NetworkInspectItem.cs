namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="NetworkInspect"/>
/// </summary>
public class NetworkInspectItem : Docker.Network, INetworkID
{
    string INetworkID.NetworkID => Name ?? Id;

    string ISessionID.SessionID { get; set; } = null!;

    public override string ToString() => Name ?? Id;
}
