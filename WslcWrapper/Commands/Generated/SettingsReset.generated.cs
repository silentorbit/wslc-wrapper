#nullable enable
namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Overwrites the settings file with a commented-out defaults template.
/// Usage: wslc settings reset [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class SettingsReset : WslcCommand
{
    /// <summary><![CDATA[
    /// Overwrites the settings file with a commented-out defaults template.
    /// Usage: wslc settings reset [<options>]
    /// ]]></summary>
    public SettingsReset() { }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("settings", "reset");
    }

}
