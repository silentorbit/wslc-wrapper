namespace SilentOrbit.WSLC.Data;

class OnlyContainerID(string id) : IContainerID
{
    public string ContainerID { get; } = id;
}