namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Exports a container's filesystem as a tar archive.
/// Usage: wslc container export [<options>] <container-id>
/// </summary>
public partial class ContainerExport : WslcCommand
{
    public required string ContainerID { get; set; }

    public ContainerExport() { }

    [SetsRequiredMembers]
    public ContainerExport(string containerid)
    {
        this.ContainerID = containerid;
    }

    /// <summary>
    /// Write to a file, instead of STDOUT
    /// --output
    /// </summary>
    public string? Output { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "export");
        args.AddOptional("--output", Output);
        args.Add(ContainerID);
    }

}
