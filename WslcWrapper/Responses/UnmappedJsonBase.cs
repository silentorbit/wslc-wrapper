using System.Diagnostics;

namespace SilentOrbit.WSLC.Responses;

public abstract class UnmappedJsonBase
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData
    {
        get => field;
        set
        {
#if DEBUG
            var type = GetType().Name;
#endif
            Debug.Fail("UnmappedData");
            field = value;
        }
    }
}
