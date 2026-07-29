namespace SilentOrbit.WSLC.Responses;

public class ResponseVolumeID(string id) : IVolumeID
{
    public string? Session { get; set; }

    public string VolumeID { get; } = id;
}
