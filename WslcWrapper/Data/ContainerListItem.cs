namespace SilentOrbit.WSLC.Data;

/// <summary>
/// Direct map of:
/// wslc container list --format json
/// 
/// <see cref="ContainerList"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class ContainerListItem
{
    public UInt64 CreatedAt { get; set; }
    public required string Id { get; set; }
    public required string Image { get; set; }
    public required string Name { get; set; }
    public required List<PortMap> Ports { get; set; }
    public ContainerState State { get; set; }
    public UInt64 StateChangedAt { get; set; }

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif

    //public string? Command { get; set; }
    //public int RunningFor { get; set; }
    //public string? Status { get; set; }
    //public string? HealthStatus { get; set; }
    //public List<string>? Labels { get; set; }
    //public List<string>? Mounts { get; set; }
    //public List<string>? Networks { get; set; }

    [JsonIgnore]
    public DateTime Created => ToLocal(CreatedAt);
    [JsonIgnore]
    public DateTime StateChanged => ToLocal(StateChangedAt);

    static DateTime ToLocal(UInt64 value)
    {
        var l = unchecked((long)value);
        var d = DateTimeOffset.FromUnixTimeSeconds(l);
        return d.LocalDateTime;
    }
}

public enum ContainerState
{
    Created = 1,
    Running = 2,
    Exited = 3,
}
