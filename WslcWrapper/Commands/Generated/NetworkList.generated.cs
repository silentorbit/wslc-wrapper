namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Lists all networks in the session.
/// Usage: wslc network list [<options>]
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class NetworkList : WslcCommandJson<List<NetworkListItem>>, IFormatJson
{
    /// <summary><![CDATA[
    /// Lists all networks in the session.
    /// Usage: wslc network list [<options>]
    /// ]]></summary>
    public NetworkList() { }

    /// <summary><![CDATA[
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// ]]></summary>
    public string? Format { get; set; }

    /// <summary><![CDATA[
    /// Outputs the network names only
    /// --quiet
    /// ]]></summary>
    public bool Quiet { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "list");
        args.AddOptional("--format", Format);
        args.AddFlag("--quiet", Quiet);
    }

}
