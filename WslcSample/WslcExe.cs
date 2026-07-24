namespace SilentOrbit.WSLC;

/// <summary>
/// Sample usage
/// </summary>
public static class WslcExe
{
    /// <summary>
    /// Run and return deserialized JSON output.
    /// </summary>
    public static TReturn RunJson<TReturn>(this WslcCommandJson<TReturn> command)
        where TReturn : class
    {
        var json = RunString(command);

        var resp = JsonSerializer.Deserialize<TReturn>(json)
            ?? throw new ArgumentNullException();

        if (resp is UnmappedJsonBase unmapped)
            Debug.Assert(unmapped.UnmappedData == null, "Unmapped data found in JSON response");

        return resp;
    }

    /// <summary>
    /// Run and return output as ID
    /// </summary>
    public static IContainerID RunID(this WslcCommandString<IContainerID> command)
    {
        var id = RunString(command);
        return new OnlyContainerID(id);
    }

    /// <summary>
    /// Run and return output as ID
    /// </summary>
    public static IVolumeID RunID(this WslcCommandString<IVolumeID> command)
    {
        var id = RunString(command);
        return new OnlyVolumeID(id);
    }

    /// <summary>
    /// Run and return output as a string.
    /// </summary>
    public static string RunString(this WslcCommand command)
    {
        var result = Run(command);

        result.ExpectOK();

        var output = result.StdOut.Trim();
        return output;
    }

    public static WslcResult Run(this WslcCommand command)
    {
        var args = command.BuildArgs();
        return Run(args);
    }

    public static WslcResult Run(IList<string> args)
    {
        if (args.Any(string.IsNullOrWhiteSpace))
            throw new ArgumentNullException(nameof(args), "Arguments can't be null or whitespace");

        var psi = new ProcessStartInfo
        {
            FileName = "wslc.exe",
            //Arguments = arguments,
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        foreach (var arg in args)
            psi.ArgumentList.Add(arg);

        using var process = new Process { StartInfo = psi };

        var stdOutBuilder = new StringBuilder();
        var stdErrBuilder = new StringBuilder();
        process.OutputDataReceived += (sender, e) =>
        {
            if (e.Data == null)
                return;

            stdOutBuilder.AppendLine(e.Data);
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data == null)
                return;

            stdErrBuilder.AppendLine(e.Data);
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        if (process.ExitCode != 0)
            throw new Exception($"Exit: {process.ExitCode}");

        var result = new WslcResult
        {
            ExitCode = process.ExitCode,
            StdOut = stdOutBuilder.ToString(),
            StdErr = stdErrBuilder.ToString()
        };

        return result;
    }
}
