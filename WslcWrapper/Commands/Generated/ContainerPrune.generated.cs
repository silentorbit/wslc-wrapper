#nullable enable
namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes all stopped containers.
/// Usage: wslc container prune [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ContainerPrune : WslcCommand
{
    /// <summary><![CDATA[
    /// Removes all stopped containers.
    /// Usage: wslc container prune [<options>]
    /// ]]></summary>
    public ContainerPrune() { }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "prune");
    }

}
