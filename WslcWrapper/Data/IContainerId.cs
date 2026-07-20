namespace SilentOrbit.WSLC.Data;

public interface IContainerID
{
    string ContainerID { get; }
}

class OnlyContainerID(string id) : IContainerID
{
    public string ContainerID { get; } = id;
}