namespace SilentOrbit.WSLC;

/// <summary>
/// Base class for all requests to wslc.exe
/// With specified return type
/// </summary>
public abstract class WslcCommand<TReturn> : WslcCommand
    where TReturn : class
{
    public TReturn RunJson()
    {
        if (this is IFormatJson format)
            format.Format = "json";

        var result = Run();

        result.ExpectOK();
        return JsonSerializer.Deserialize<TReturn>(result.StdOut)
            ?? throw new ArgumentNullException();
    }
}

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

    public WslcResult Run()
    {
        var args = BuildArgs();
        return WslcExe.Run(args);
    }

    public List<string> BuildArgs()
    {
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

