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
    public Dictionary<string, string> Label { get; set; } = [];

    /// <summary><![CDATA[
    /// IPv4 or IPv6 gateway for the subnet
    /// --gateway
    /// ]]></summary>
    public string? Gateway { get; set; }

    /// <summary><![CDATA[
    /// Restrict external access to the network
    /// --internal
    /// ]]></summary>
    public bool Internal { get; set; }

    /// <summary><![CDATA[
    /// Subnet in CIDR format that represents a network segment
    /// --subnet
    /// ]]></summary>
    public string? Subnet { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "create");
        args.AddOptional("--driver", Driver);
        args.AddOptional("--opt", Opt);
        args.AddOptional("--label", Label);
        args.AddOptional("--gateway", Gateway);
        args.AddFlag("--internal", Internal);
        args.AddOptional("--subnet", Subnet);
        args.Add(NetworkName);
    }

}
