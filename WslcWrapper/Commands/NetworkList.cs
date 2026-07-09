namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Lists all networks in the session.
/// Usage: wslc network list [<options>]
/// </summary>
public partial class NetworkList : WslcCommand
{
    public NetworkList() { }

    /// <summary>
    /// Output formatting (json or table) (Default: table)
    /// --format
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Outputs the network names only
    /// --quiet
    /// </summary>
    public bool Quiet { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "list");
        args.AddOptional("--format", Format);
        args.AddFlag("--quiet", Quiet);
    }

}
