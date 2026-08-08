using System.Linq;

namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="ImageInspect"/>
/// </summary>
public class ImageInspectItem : Docker.ImageInspect, IImageID
{
    [JsonIgnore]
    string ISessionID.SessionID { get; set; } = null!;

    [JsonIgnore]
    public string ImageID => RepoTags.FirstOrDefault() ?? RepoDigests.FirstOrDefault() ?? Id;

    public string? Parent { get; set; }


    public override string ToString() => Id;
}
