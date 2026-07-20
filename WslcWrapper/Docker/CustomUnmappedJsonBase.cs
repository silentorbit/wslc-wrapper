namespace SilentOrbit.WSLC.Docker;


public partial class ImageInspect : UnmappedJsonBase
{
}

public partial class Network : UnmappedJsonBase
{
}

public partial class MountPoint : UnmappedJsonBase
{
    /// <summary>
    /// Observed in wslc.exe container inspect output,
    /// but not in the official Docker API documentation.
    /// </summary>
    [JsonPropertyName("ReadWrite")]
    public bool ReadWrite { get => RW ?? false; set => RW = value; }
}

public partial class ContainerInspectResponse : UnmappedJsonBase
{
}

public partial class Volume : UnmappedJsonBase
{
}

