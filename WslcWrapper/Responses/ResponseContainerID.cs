namespace SilentOrbit.WSLC.Responses;

public class ResponseContainerID(string id) : IContainerID
{
    public string? Session { get; set; }

    public string ContainerID { get; } = id;
}