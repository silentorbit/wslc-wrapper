#nullable enable
namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Show version information for this tool.
/// Usage: wslc version [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class Version : WslcCommand
{
    /// <summary><![CDATA[
    /// Show version information for this tool.
    /// Usage: wslc version [<options>]
    /// ]]></summary>
    public Version() { }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("version");
    }

}
