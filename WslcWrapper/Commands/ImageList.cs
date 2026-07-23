namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Lists images.
/// Usage: wslc image list [<options>]
/// ]]></summary>
public partial class ImageList : WslcCommandJson<List<ImageListItem>>, IFormatJson
{
    /// <summary><![CDATA[
    /// Lists images.
    /// Usage: wslc image list [<options>]
    /// ]]></summary>
    public ImageList() { }

    /// <summary><![CDATA[
    /// Filter output based on conditions provided
    /// --filter
    /// ]]></summary>
    public IList<string> Filter { get; set; } = [];

    /// <summary><![CDATA[
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// ]]></summary>
    public string? Format { get; set; }

    /// <summary><![CDATA[
    /// Do not truncate output
    /// --no-trunc
    /// ]]></summary>
    public bool NoTrunc { get; set; }

    /// <summary><![CDATA[
    /// Outputs the container IDs only
    /// --quiet
    /// ]]></summary>
    public bool Quiet { get; set; }

    /// <summary><![CDATA[
    /// Output verbose details
    /// --verbose
    /// ]]></summary>
    public string? Verbose { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "list");
        foreach (var v in Filter)
            args.AddRange("--filter", v);
        args.AddOptional("--format", Format);
        args.AddFlag("--no-trunc", NoTrunc);
        args.AddFlag("--quiet", Quiet);
        args.AddOptional("--verbose", Verbose);
    }

}
