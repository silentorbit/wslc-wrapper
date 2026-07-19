using System.Diagnostics;
using System.Linq;
using System.Text;

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

        using var process = new Process { StartInfo = psi };

        var stdOutBuilder = new StringBuilder();
        var stdErrBuilder = new StringBuilder();
        process.OutputDataReceived += (sender, e) =>
        {
            if (e.Data != null) // e.Data is null when the stream is closed
            {
                Console.WriteLine(e.Data);    // Read/print in real-time
                stdOutBuilder.AppendLine(e.Data); // Store for the final result
            }
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                Console.Error.WriteLine(e.Data);
                stdErrBuilder.AppendLine(e.Data);
            }
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
