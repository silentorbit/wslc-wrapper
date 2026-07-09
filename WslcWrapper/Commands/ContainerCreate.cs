namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Creates a container.
/// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
/// </summary>
public partial class ContainerCreate : WslcCommand
{
    public required string Image { get; set; }

    public string? Command { get; set; }

    public required IList<string> Arguments { get; set; }

    public ContainerCreate() { }

    [SetsRequiredMembers]
    public ContainerCreate(string image, string? command = null, params IList<string> arguments)
    {
        this.Image = image;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary>
    /// Write the container ID to the provided path
    /// --cidfile
    /// </summary>
    public string? Cidfile { get; set; }

    /// <summary>
    /// Number of CPUs (e.g. 0.5, 1, 2.5)
    /// --cpus
    /// </summary>
    public string? CPUs { get; set; }

    /// <summary>
    /// IP address of the DNS nameserver in resolv.conf
    /// --dns
    /// </summary>
    public string? DNS { get; set; }

    /// <summary>
    /// Set DNS options
    /// --dns-option
    /// </summary>
    public string? DnsOption { get; set; }

    /// <summary>
    /// Set DNS search domains
    /// --dns-search
    /// </summary>
    public string? DnsSearch { get; set; }

    /// <summary>
    /// Container domain name
    /// --domainname
    /// </summary>
    public string? Domainname { get; set; }

    /// <summary>
    /// Specifies the container init process executable
    /// --entrypoint
    /// </summary>
    public string? Entrypoint { get; set; }

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
    /// Add GPU devices to the container ('all' to pass all GPUs)
    /// --gpus
    /// </summary>
    public string? GPUs { get; set; }

    /// <summary>
    /// Container host name
    /// --hostname
    /// </summary>
    public string? Hostname { get; set; }

    /// <summary>
    /// Attach to stdin and keep it open
    /// --interactive
    /// </summary>
    public bool Interactive { get; set; }

    /// <summary>
    /// Set metadata on an object
    /// --label
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Memory limit (e.g. 512M, 1G)
    /// --memory
    /// </summary>
    public string? Memory { get; set; }

    /// <summary>
    /// Name of the container
    /// --name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Connect a container to a network
    /// --network
    /// </summary>
    public string? Network { get; set; }

    /// <summary>
    /// Add a network-scoped alias for the container
    /// --network-alias
    /// </summary>
    public string? NetworkAlias { get; set; }

    /// <summary>
    /// Publish a port from a container to host
    /// --publish
    /// </summary>
    public List<PortMap> Publish { get; set; } = [];

    /// <summary>
    /// Publish all exposed ports to random host ports
    /// --publish-all
    /// </summary>
    public bool PublishAll { get; set; }

    /// <summary>
    /// Remove the container after it stops
    /// --rm
    /// </summary>
    public bool RM { get; set; }

    /// <summary>
    /// Size of /dev/shm (e.g. 64M, 1G)
    /// --shm-size
    /// </summary>
    public string? ShmSize { get; set; }

    /// <summary>
    /// Signal to stop the container
    /// --stop-signal
    /// </summary>
    public string? StopSignal { get; set; }

    /// <summary>
    /// Mount tmpfs to the container at the given path
    /// --tmpfs
    /// </summary>
    public string? Tmpfs { get; set; }

    /// <summary>
    /// Open a TTY with the container process.
    /// --tty
    /// </summary>
    public bool TTY { get; set; }

    /// <summary>
    /// Ulimit options (format: <name>=<soft>[:<hard>], use -1 for unlimited)
    /// --ulimit
    /// </summary>
    public string? ULimit { get; set; }

    /// <summary>
    /// User ID for the process (name|uid|uid:gid)
    /// --user
    /// </summary>
    public string? User { get; set; }

    /// <summary>
    /// Bind mount a volume to the container
    /// --volume
    /// </summary>
    public List<VolumeArg> Volume { get; set; } = [];

    /// <summary>
    /// Working directory inside the container
    /// --workdir
    /// </summary>
    public string? Workdir { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("container", "create");
        args.AddOptional("--cidfile", Cidfile);
        args.AddOptional("--cpus", CPUs);
        args.AddOptional("--dns", DNS);
        args.AddOptional("--dns-option", DnsOption);
        args.AddOptional("--dns-search", DnsSearch);
        args.AddOptional("--domainname", Domainname);
        args.AddOptional("--entrypoint", Entrypoint);
        args.AddOptional("--env", Env);
        args.AddOptional("--env-file", EnvFile);
        args.AddOptional("--gpus", GPUs);
        args.AddOptional("--hostname", Hostname);
        args.AddFlag("--interactive", Interactive);
        args.AddOptional("--label", Label);
        args.AddOptional("--memory", Memory);
        args.AddOptional("--name", Name);
        args.AddOptional("--network", Network);
        args.AddOptional("--network-alias", NetworkAlias);
        args.AddOptional("--publish", Publish);
        args.AddFlag("--publish-all", PublishAll);
        args.AddFlag("--rm", RM);
        args.AddOptional("--shm-size", ShmSize);
        args.AddOptional("--stop-signal", StopSignal);
        args.AddOptional("--tmpfs", Tmpfs);
        args.AddFlag("--tty", TTY);
        args.AddOptional("--ulimit", ULimit);
        args.AddOptional("--user", User);
        args.AddOptional("--volume", Volume);
        args.AddOptional("--workdir", Workdir);
        args.Add(Image);
        args.AddOptional(Command);
        args.AddRange(Arguments);
    }

}
