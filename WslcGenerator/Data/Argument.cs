namespace SilentOrbit.WSLC.Data;

internal class Argument(string key, string help)
{
    public string Key { get; } = key;

    public string Summary { get; } = help;

    public override string ToString() => $"{Key}\t{Summary}";
}
