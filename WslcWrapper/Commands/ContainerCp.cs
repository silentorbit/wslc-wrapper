namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Copy files between a container and the local filesystem.
/// Usage: wslc container cp [OPTIONS] SOURCE DEST
///   Local to container: wslc container cp LOCAL_PATH CONTAINER:PATH
///   Container to local: wslc container cp CONTAINER:PATH LOCAL_PATH
///   Stdin to container: wslc container cp - CONTAINER:PATH
/// Usage: wslc container cp [<options>] <source> <target>
/// ]]></summary>
public partial class ContainerCp : WslcCommand
{
    /// <summary>
    /// Source: local path, CONTAINER:PATH, or '-' for stdin
    /// </summary>
    public required string Source { get; set; }

    /// <summary>
    /// Destination: local path or CONTAINER:PATH
    /// </summary>
    public required string Target { get; set; }

    /// <summary><![CDATA[
    /// Copy files between a container and the local filesystem.
    /// Usage: wslc container cp [OPTIONS] SOURCE DEST
    ///   Local to container: wslc container cp LOCAL_PATH CONTAINER:PATH
    ///   Container to local: wslc container cp CONTAINER:PATH LOCAL_PATH
    ///   Stdin to container: wslc container cp - CONTAINER:PATH
    /// Usage: wslc container cp [<options>] <source> <target>
    /// ]]></summary>
    public ContainerCp() { }

    /// <summary><![CDATA[
    /// Copy files between a container and the local filesystem.
    /// Usage: wslc container cp [OPTIONS] SOURCE DEST
    ///   Local to container: wslc container cp LOCAL_PATH CONTAINER:PATH
    ///   Container to local: wslc container cp CONTAINER:PATH LOCAL_PATH
    ///   Stdin to container: wslc container cp - CONTAINER:PATH
    /// Usage: wslc container cp [<options>] <source> <target>
    /// ]]></summary>
    /// <param name="source">Source: local path, CONTAINER:PATH, or '-' for stdin</param>
    /// <param name="target">Destination: local path or CONTAINER:PATH</param>
    [SetsRequiredMembers]
    public ContainerCp(string source, string target)
    {
        this.Source = source;
        this.Target = target;
    }

    /// <summary><![CDATA[
    /// Archive mode (accepted for Docker CLI compatibility)
    /// --archive
    /// ]]></summary>
    public bool Archive { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "cp");
        args.AddFlag("--archive", Archive);
        args.Add(Source);
        args.Add(Target);
    }

}
