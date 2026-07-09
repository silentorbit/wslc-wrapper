namespace SilentOrbit.WSLC.Data;

/// <summary>
/// wslc.exe image list --format json
/// </summary>
public class ImageInfo
{
    public required long Created { get; set; }
    public required string Id { get; set; }
    public required string Repository { get; set; }
    public required ulong Size { get; set; }
    public required string Tag { get; set; }

    [JsonIgnore]
    public string RepositoryOrId => Repository ?? Id;
}

