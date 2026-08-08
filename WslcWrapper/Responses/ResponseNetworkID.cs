namespace SilentOrbit.WSLC.Responses;

public class ResponseNetworkID(string id) : INetworkID
{
    public string SessionID { get; set; } = null!;

    public string NetworkID { get; } = id;
}
