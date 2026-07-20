namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Lists all volumes in the session.
/// Usage: wslc volume list [<options>]
/// ]]></summary>
public partial class VolumeList : WslcCommandJson<List<VolumeListItem>>, IFormatJson
{
    /// <summary><![CDATA[
    /// Lists all volumes in the session.
    /// Usage: wslc volume list [<options>]
    /// ]]></summary>
    public VolumeList() { }

    /// <summary><![CDATA[
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// ]]></summary>
    public string? Format { get; set; }

    /// <summary><![CDATA[
    /// Outputs the volume names only
    /// --quiet
    /// ]]></summary>
    public bool Quiet { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("volume", "list");
        args.AddOptional("--format", Format);
        args.AddFlag("--quiet", Quiet);
    }

}
