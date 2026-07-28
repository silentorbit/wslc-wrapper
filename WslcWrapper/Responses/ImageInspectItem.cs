namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="ImageInspect"/>
/// </summary>
public class ImageInspectItem : Docker.ImageInspect
{
    public string? Parent { get; set; }

    public override string ToString() => Id;
}
