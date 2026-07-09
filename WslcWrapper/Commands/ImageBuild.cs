namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Builds an image from a Dockerfile and a build context directory.
/// Usage: wslc image build [<options>] <path>
/// </summary>
public partial class ImageBuild : WslcCommand
{
    public required string Path { get; set; }

    public ImageBuild() { }

    [SetsRequiredMembers]
    public ImageBuild(string path)
    {
        this.Path = path;
    }

    /// <summary>
    /// Set build-time variables (KEY=VALUE)
    /// --build-arg
    /// </summary>
    public string? BuildArg { get; set; }

    /// <summary>
    /// Always attempt to pull a newer version of the image
    /// --pull
    /// </summary>
    public string? Pull { get; set; }

    /// <summary>
    /// Set the target build stage to build
    /// --target
    /// </summary>
    public string? Target { get; set; }

    /// <summary>
    /// Path to the Dockerfile (use "-" to read from stdin)
    /// --file
    /// </summary>
    public string? File { get; set; }

    /// <summary>
    /// Set metadata on an object
    /// --label
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Do not use cache when building the image
    /// --no-cache
    /// </summary>
    public bool NoCache { get; set; }

    /// <summary>
    /// Tag for the built image
    /// --tag
    /// </summary>
    public string? Tag { get; set; }

    /// <summary>
    /// Output verbose details
    /// --verbose
    /// </summary>
    public string? Verbose { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("image", "build");
        args.AddOptional("--build-arg", BuildArg);
        args.AddOptional("--pull", Pull);
        args.AddOptional("--target", Target);
        args.AddOptional("--file", File);
        args.AddOptional("--label", Label);
        args.AddFlag("--no-cache", NoCache);
        args.AddOptional("--tag", Tag);
        args.AddOptional("--verbose", Verbose);
        args.Add(Path);
    }

}
