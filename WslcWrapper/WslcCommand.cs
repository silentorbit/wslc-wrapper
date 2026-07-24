namespace SilentOrbit.WSLC;

/// <summary>
/// Base class for all requests to wslc.exe
/// </summary>
public abstract class WslcCommand
{
    /// <summary>
    /// wslc.exe --session MySession ...
    /// </summary>
    public string? Session { get; set; }

    /// <summary>
    /// Shows help about the selected command
    /// --help
    /// </summary>
    public bool Help { get; set; }

    public List<string> BuildArgs()
    {
        if (this is IFormatJson format)
            format.Format ??= "json";

        var args = new List<string>();
        if (Session != null)
            args.AddRange("--session", Session);

        BuildArgs(args);

        if (Help)
            args.Add("--help");
        return args;
    }

    protected abstract void BuildArgs(List<string> args);
}

/// <summary>
/// Base class for all requests to wslc.exe with JSON response.
/// </summary>
public abstract class WslcCommandJson<TReturn> : WslcCommand
    where TReturn : class
{
    
}

/// <summary>
/// Base class for all requests to wslc.exe that return a string id.
/// </summary>
public abstract class WslcCommandString<TReturn> : WslcCommand
    where TReturn : class
{

}
