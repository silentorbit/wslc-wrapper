using System.Diagnostics;

namespace SilentOrbit.WSLC;

public class WslcResult
{
    public required int ExitCode { get; set; }
    public required string StdOut { get; set; }
    public required string StdErr { get; set; }

    public WslcResult ExpectOK()
    {
        if (ExitCode == 0)
            return this;

        Debug.Fail($"Expected ok, got {ExitCode}");
        throw new Exception($"Exit: {ExitCode}\n{StdErr}\n{StdOut}");
    }
}
