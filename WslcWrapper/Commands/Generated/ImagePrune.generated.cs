namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Removes all dangling images. If --all is specified, removes all images not used by any container.
/// Usage: wslc image prune [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class ImagePrune : WslcCommand
{
    /// <summary><![CDATA[
    /// Removes all dangling images. If --all is specified, removes all images not used by any container.
    /// Usage: wslc image prune [<options>]
    /// ]]></summary>
    public ImagePrune() { }

    /// <summary><![CDATA[
    /// Remove all unused images, not just dangling ones.
    /// --all
    /// ]]></summary>
    public bool All { get; set; }

    /// <summary><![CDATA[
    /// Filter output based on conditions provided
    /// --filter
    /// ]]></summary>
    public IList<string> Filter { get; set; } = [];

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "prune");
        args.AddFlag("--all", All);
        foreach (var v in Filter)
            args.AddRange("--filter", v);
    }

}
