
/// <summary>
/// <see cref="ImageList"/>
/// </summary>
public class ImageListItem : UnmappedJsonBase, IImageID
{
    public required long Created { get; set; }
    public required string Id { get; set; }
    public required string Repository { get; set; }
    public required ulong Size { get; set; }
    public required string Tag { get; set; }

    [JsonIgnore]
    public string ImageID
    {
        get
        {
            if (Repository == null || Tag == null)
                return Id;
            else
                return $"{Repository}:{Tag}";
        }
    }

    public override string ToString() => ImageID;
}

