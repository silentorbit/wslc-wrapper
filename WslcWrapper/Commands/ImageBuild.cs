namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Builds an image from a Dockerfile and a build context directory.
/// Usage: wslc image build [<options>] <path>
/// ]]></summary>
public partial class ImageBuild : WslcCommand
{
    /// <summary>
    /// Path to the build context directory
    /// </summary>
    public required string Path { get; set; }

    /// <summary><![CDATA[
    /// Builds an image from a Dockerfile and a build context directory.
    /// Usage: wslc image build [<options>] <path>
    /// ]]></summary>
    public ImageBuild() { }

    /// <summary><![CDATA[
    /// Builds an image from a Dockerfile and a build context directory.
    /// Usage: wslc image build [<options>] <path>
    /// ]]></summary>
    /// <param name="path">Path to the build context directory</param>
    [SetsRequiredMembers]
    public ImageBuild(string path)
    {
        this.Path = path;
    }

    /// <summary><![CDATA[
    /// Set build-time variables (KEY=VALUE)
    /// --build-arg
    /// ]]></summary>
    public string? BuildArg { get; set; }

    /// <summary><![CDATA[
    /// Always attempt to pull a newer version of the image
    /// --pull
    /// ]]></summary>
    public string? Pull { get; set; }

    /// <summary><![CDATA[
    /// Set the target build stage to build
    /// --target
    /// ]]></summary>
    public string? Target { get; set; }

    /// <summary><![CDATA[
    /// Path to the Dockerfile (use "-" to read from stdin)
    /// --file
    /// ]]></summary>
    public string? File { get; set; }

    /// <summary><![CDATA[
    /// Set metadata on an object
    /// --label
    /// ]]></summary>
    public IList<EnvValue> Label { get; set; } = [];

    /// <summary><![CDATA[
    /// Do not use cache when building the image
    /// --no-cache
    /// ]]></summary>
    public bool NoCache { get; set; }

    /// <summary><![CDATA[
    /// Tag for the built image
    /// --tag
    /// ]]></summary>
    public string? Tag { get; set; }

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
