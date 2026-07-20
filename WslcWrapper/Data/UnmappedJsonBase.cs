using System.Diagnostics;

namespace SilentOrbit.WSLC.Data;

public abstract class UnmappedJsonBase
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? UnmappedData
    {
        get => field;
        set => field = value;
        /*
        {
#if DEBUG
            var type = GetType().Name;
#endif
            Debug.Fail("UnmappedData");
            field = value;
        }*/
    }
}
