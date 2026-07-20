namespace SilentOrbit.WSLC.Data;

public interface IVolumeID
{
    string VolumeID { get; }
}

class OnlyVolumeID(string id) : IVolumeID
{
    public string VolumeID { get; } = id;
}
