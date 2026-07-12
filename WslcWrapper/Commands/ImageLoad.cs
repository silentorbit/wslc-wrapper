namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Loads images.
/// Usage: wslc image load [<options>]
/// ]]></summary>
public partial class ImageLoad : WslcCommand
{
    /// <summary><![CDATA[
    /// Loads images.
    /// Usage: wslc image load [<options>]
    /// ]]></summary>
    public ImageLoad() { }

    /// <summary><![CDATA[
    /// Provides path to the tar archive file containing the image
    /// --input
    /// ]]></summary>
    public string? Input { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "load");
        args.AddOptional("--input", Input);
    }

}
