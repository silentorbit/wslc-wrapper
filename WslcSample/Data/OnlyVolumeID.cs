namespace SilentOrbit.WSLC.Data;

class OnlyVolumeID(string id) : IVolumeID
{
    public string VolumeID { get; } = id;
}
