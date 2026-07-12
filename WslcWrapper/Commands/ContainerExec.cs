namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Executes a command in a running container.
/// Usage: wslc container exec [<options>] <container-id> <command> [<arguments>...]
/// ]]></summary>
public partial class ContainerExec : WslcCommand
{
    /// <summary>
    /// Container ID
    /// </summary>
    public required string ContainerID { get; set; }

    /// <summary>
    /// The command to run
    /// </summary>
    public required string Command { get; set; }

    /// <summary>
    /// Arguments to pass to the command being executed inside the container
    /// </summary>
    public required IList<string> Arguments { get; set; }

    /// <summary><![CDATA[
    /// Executes a command in a running container.
    /// Usage: wslc container exec [<options>] <container-id> <command> [<arguments>...]
    /// ]]></summary>
    public ContainerExec() { }

    /// <summary><![CDATA[
    /// Executes a command in a running container.
    /// Usage: wslc container exec [<options>] <container-id> <command> [<arguments>...]
    /// ]]></summary>
    /// <param name="containerid">Container ID</param>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to the command being executed inside the container</param>
    [SetsRequiredMembers]
    public ContainerExec(string containerid, string command, params IList<string> arguments)
    {
        this.ContainerID = containerid;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary><![CDATA[
    /// Executes a command in a running container.
    /// Usage: wslc container exec [<options>] <container-id> <command> [<arguments>...]
    /// ]]></summary>
    /// <param name="container">Container ID</param>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to the command being executed inside the container</param>
    [SetsRequiredMembers]
    public ContainerExec(IContainerID container, string command, params IList<string> arguments)
    {
        this.ContainerID = container.ContainerID;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary><![CDATA[
    /// Run container in detached mode
    /// --detach
    /// ]]></summary>
    public bool Detach { get; set; }

    /// <summary><![CDATA[
    /// Key=Value pairs for environment variables
    /// --env
    /// ]]></summary>
    public List<EnvValue> Env { get; set; } = [];

    /// <summary><![CDATA[
    /// File containing key=value pairs of env variables
    /// --env-file
    /// ]]></summary>
    public string? EnvFile { get; set; }

    /// <summary><![CDATA[
    /// Attach to stdin and keep it open
    /// --interactive
    /// ]]></summary>
    public bool Interactive { get; set; }

    /// <summary><![CDATA[
    /// Open a TTY with the container process.
    /// --tty
    /// ]]></summary>
    public bool TTY { get; set; }

    /// <summary><![CDATA[
    /// User ID for the process (name|uid|uid:gid)
    /// --user
    /// ]]></summary>
    public string? User { get; set; }

    /// <summary><![CDATA[
    /// Working directory inside the container
    /// --workdir
    /// ]]></summary>
    public string? Workdir { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "exec");
        args.AddFlag("--detach", Detach);
        args.AddOptional("--env", Env);
        args.AddOptional("--env-file", EnvFile);
        args.AddFlag("--interactive", Interactive);
        args.AddFlag("--tty", TTY);
        args.AddOptional("--user", User);
        args.AddOptional("--workdir", Workdir);
        args.Add(ContainerID);
        args.Add(Command);
        args.AddRange(Arguments);
    }

}
