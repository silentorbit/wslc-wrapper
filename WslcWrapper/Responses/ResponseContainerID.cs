namespace SilentOrbit.WSLC.Responses;

public class ResponseContainerID(string id) : IContainerID
{
    public string SessionID { get; set; } = null!;

    public string ContainerID { get; } = id;
}