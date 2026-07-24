namespace SilentOrbit.WSLC.Responses;

/// <summary>
/// <see cref="ImageInspect"/>.<see cref="WslcCommandJson{T}.RunJson"/>
/// </summary>
public class ImageInspectItem : Docker.ImageInspect
{
    public override string ToString() => Id;
}
