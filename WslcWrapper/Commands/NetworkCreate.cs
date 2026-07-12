namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Creates a new network.
/// Usage: wslc network create [<options>] <network-name>
/// ]]></summary>
public partial class NetworkCreate : WslcCommand
{
    /// <summary>
    /// Network name
    /// </summary>
    public required string NetworkName { get; set; }

    /// <summary><![CDATA[
    /// Creates a new network.
    /// Usage: wslc network create [<options>] <network-name>
    /// ]]></summary>
    public NetworkCreate() { }

    /// <summary><![CDATA[
    /// Creates a new network.
    /// Usage: wslc network create [<options>] <network-name>
    /// ]]></summary>
    /// <param name="networkname">Network name</param>
    [SetsRequiredMembers]
    public NetworkCreate(string networkname)
    {
        this.NetworkName = networkname;
    }

    /// <summary><![CDATA[
    /// Specify network driver name (default: bridge)
    /// --driver
    /// ]]></summary>
    public string? Driver { get; set; }

    /// <summary><![CDATA[
    /// Set driver specific options
    /// --opt
    /// ]]></summary>
    public string? Opt { get; set; }

    /// <summary><![CDATA[
    /// Network metadata setting
    /// --label
    /// ]]></summary>
    public string? Label { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "create");
        args.AddOptional("--driver", Driver);
        args.AddOptional("--opt", Opt);
        args.AddOptional("--label", Label);
        args.Add(NetworkName);
    }

}
