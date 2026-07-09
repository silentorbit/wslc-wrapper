namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Executes a command in a running container.
/// Usage: wslc container exec [<options>] <container-id> <command> [<arguments>...]
/// </summary>
public partial class ContainerExec : WslcCommand
{
    public required string ContainerID { get; set; }

    public required string Command { get; set; }

    public required IList<string> Arguments { get; set; }

    public ContainerExec() { }

    [SetsRequiredMembers]
    public ContainerExec(string containerid, string command, params IList<string> arguments)
    {
        this.ContainerID = containerid;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary>
    /// Run container in detached mode
    /// --detach
    /// </summary>
    public bool Detach { get; set; }

    /// <summary>
    /// Key=Value pairs for environment variables
    /// --env
    /// </summary>
    public List<EnvValue> Env { get; set; } = [];

    /// <summary>
    /// File containing key=value pairs of env variables
    /// --env-file
    /// </summary>
    public string? EnvFile { get; set; }

    /// <summary>
    /// Attach to stdin and keep it open
    /// --interactive
    /// </summary>
    public bool Interactive { get; set; }

    /// <summary>
    /// Open a TTY with the container process.
    /// --tty
    /// </summary>
    public bool TTY { get; set; }

    /// <summary>
    /// User ID for the process (name|uid|uid:gid)
    /// --user
    /// </summary>
    public string? User { get; set; }

    /// <summary>
    /// Working directory inside the container
    /// --workdir
    /// </summary>
    public string? Workdir { get; set; }

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
