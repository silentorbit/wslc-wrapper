namespace SilentOrbit.WSLC.Data;

internal class Argument(string key, string summary)
{
    /// <summary>
    /// --option or argument-name
    /// Sent to wslc.exe
    /// </summary>
    public string Key { get; } = key;

    public string Summary { get; } = summary;

    #region code generation

    public string PropertyType { get; set; } = null!;
    public string PropertyName { get; set; } = null!;
    public string CtorParameterType { get; set; } = null!;
    public string CtorParameterName { get; set; } = null!;
    public string CtorPropertyValue { get; set; } = null!;

    #endregion code generation

    public override string ToString() => $"{Key}\t{Summary}";
}
