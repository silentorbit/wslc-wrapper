
/// <summary>
/// <see cref="ImageList"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class ImageListItem : IImageID
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

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    public override string ToString() => ImageID;
}

