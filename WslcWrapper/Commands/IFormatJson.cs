namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// All commands where the --format json must be added to get a JSON response
/// </summary>
public interface IFormatJson
{
    public string? Format { get; set; }
}
