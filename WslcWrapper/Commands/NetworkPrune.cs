namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Removes all unused networks. A network is considered unused when it is not referenced by any container.
/// Usage: wslc network prune [<options>]
/// </summary>
public partial class NetworkPrune : WslcCommand
{
    public NetworkPrune() { }

    /// <summary>
    /// Filter output based on conditions provided
    /// --filter
    /// </summary>
    public string? Filter { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("network", "prune");
        args.AddOptional("--filter", Filter);
    }

}
