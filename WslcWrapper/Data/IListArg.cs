namespace SilentOrbit.WSLC.Data;

/// <summary>
/// For use in <see cref="ListExtension.AddOptional(List{string}, string, IEnumerable{IListArg}?)"/>
/// </summary>
public interface IListArg
{
    /// <summary>
    /// Generate the value component in a flag.
    /// </summary>
    string BuildArg();
}
