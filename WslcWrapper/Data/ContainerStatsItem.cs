namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ContainerStats"/>.<see cref="WslcCommand{T}.RunJson"/>
/// </summary>
public class ContainerStatsItem : IContainerID
{
    public required string BlockIO { get; set; } // "0 B / 0 B",
    public required string CPUPerc { get; set; } // "0.00%",
    public required string ID { get; set; } // "bcb27...",
    public required string MemPerc { get; set; } // "0.00%",
    public required string MemUsage { get; set; } // "0 B / 0 B",
    public required string Name { get; set; } // "crisp_alps",
    public required string NetIO { get; set; } // "0 B / 0 B",
    public required int PIDs { get; set; } // 0

    [JsonIgnore]
    string IContainerID.ContainerID => ID;

#if !DEBUG
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData { get; set; }
#endif
}
