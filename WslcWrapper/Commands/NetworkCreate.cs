namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Creates a new network.
/// Usage: wslc network create [<options>] <network-name>
/// </summary>
public partial class NetworkCreate : WslcCommand
{
    public required string NetworkName { get; set; }

    public NetworkCreate() { }

    [SetsRequiredMembers]
    public NetworkCreate(string networkname)
    {
        this.NetworkName = networkname;
    }

    /// <summary>
    /// Specify network driver name (default: bridge)
    /// --driver
    /// </summary>
    public string? Driver { get; set; }

    /// <summary>
    /// Set driver specific options
    /// --opt
    /// </summary>
    public string? Opt { get; set; }

    /// <summary>
    /// Network metadata setting
    /// --label
    /// </summary>
    public string? Label { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "create");
        args.AddOptional("--driver", Driver);
        args.AddOptional("--opt", Opt);
        args.AddOptional("--label", Label);
        args.Add(NetworkName);
    }

}
