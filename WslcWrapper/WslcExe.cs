using System.Diagnostics;
using System.Linq;

namespace SilentOrbit.WSLC;

public static class WslcExe
{
    public static WslcResult Run(IList<string> args)
    {
        if (args.Any(string.IsNullOrWhiteSpace))
            throw new ArgumentNullException("Arguments can't be null or whitespace");

        var psi = new ProcessStartInfo
        {
            FileName = "wslc.exe",
            //Arguments = arguments,
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        foreach (var arg in args)
            psi.ArgumentList.Add(arg);

        using var process = Process.Start(psi)!;
        process.WaitForExit();

        if (process.ExitCode != 0)
            throw new Exception($"Exit: {process.ExitCode}");

        var result = new WslcResult
        {
            ExitCode = process.ExitCode,
            StdOut = process.StandardOutput.ReadToEnd(),
            StdErr = process.StandardError.ReadToEnd()
        };
        
        return result;
    }
}
