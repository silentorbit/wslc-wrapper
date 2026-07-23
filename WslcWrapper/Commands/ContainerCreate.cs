namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Creates a container.
/// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
/// ]]></summary>
public partial class ContainerCreate : WslcCommandString<IContainerID>
{
    /// <summary>
    /// Image name
    /// </summary>
    public required string Image { get; set; }

    /// <summary>
    /// The command to run
    /// </summary>
    public string? Command { get; set; }

    /// <summary>
    /// Arguments to pass to container's init process
    /// </summary>
    public IList<string>? Arguments { get; set; }

    /// <summary><![CDATA[
    /// Creates a container.
    /// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
    /// ]]></summary>
    public ContainerCreate() { }

    /// <summary><![CDATA[
    /// Creates a container.
    /// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
    /// ]]></summary>
    /// <param name="image">Image name</param>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to container's init process</param>
    [SetsRequiredMembers]
    public ContainerCreate(string image, string? command = null, params IList<string>? arguments)
    {
        this.Image = image;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary><![CDATA[
    /// Creates a container.
    /// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
    /// ]]></summary>
    /// <param name="image">Image name</param>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to container's init process</param>
    [SetsRequiredMembers]
    public ContainerCreate(IImageID image, string? command = null, params IList<string>? arguments)
    {
        this.Image = image.ImageID;
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary><![CDATA[
    /// Write the container ID to the provided path
    /// --cidfile
    /// ]]></summary>
    public string? Cidfile { get; set; }

    /// <summary><![CDATA[
    /// Number of CPUs (e.g. 0.5, 1, 2.5)
    /// --cpus
    /// ]]></summary>
    public string? CPUs { get; set; }

    /// <summary><![CDATA[
    /// IP address of the DNS nameserver in resolv.conf
    /// --dns
    /// ]]></summary>
    public string? DNS { get; set; }

    /// <summary><![CDATA[
    /// Set DNS options
    /// --dns-option
    /// ]]></summary>
    public string? DnsOption { get; set; }

    /// <summary><![CDATA[
    /// Set DNS search domains
    /// --dns-search
    /// ]]></summary>
    public string? DnsSearch { get; set; }

    /// <summary><![CDATA[
    /// Container domain name
    /// --domainname
    /// ]]></summary>
    public string? Domainname { get; set; }

    /// <summary><![CDATA[
    /// Specifies the container init process executable
    /// --entrypoint
    /// ]]></summary>
    public string? Entrypoint { get; set; }

    /// <summary><![CDATA[
    /// Key=Value pairs for environment variables
    /// --env
    /// ]]></summary>
    public IList<EnvValue> Env { get; set; } = [];

    /// <summary><![CDATA[
    /// File containing key=value pairs of env variables
    /// --env-file
    /// ]]></summary>
    public string? EnvFile { get; set; }

    /// <summary><![CDATA[
    /// Add GPU devices to the container ('all' to pass all GPUs)
    /// --gpus
    /// ]]></summary>
    public string? GPUs { get; set; }

    /// <summary><![CDATA[
    /// Command to run to check container health
    /// --health-cmd
    /// ]]></summary>
    public string? HealthCmd { get; set; }

    /// <summary><![CDATA[
    /// Time between running the health check (e.g. 30s, 1m30s)
    /// --health-interval
    /// ]]></summary>
    public string? HealthInterval { get; set; }

    /// <summary><![CDATA[
    /// Consecutive failures needed to report the container as unhealthy
    /// --health-retries
    /// ]]></summary>
    public int? HealthRetries { get; set; }

    /// <summary><![CDATA[
    /// Start period for the container to initialize before health-check countdown (e.g. 30s, 1m30s)
    /// --health-start-period
    /// ]]></summary>
    public string? HealthStartPeriod { get; set; }

    /// <summary><![CDATA[
    /// Maximum time to allow one health check to run (e.g. 30s, 1m30s)
    /// --health-timeout
    /// ]]></summary>
    public string? HealthTimeout { get; set; }

    /// <summary><![CDATA[
    /// Container host name
    /// --hostname
    /// ]]></summary>
    public string? Hostname { get; set; }

    /// <summary><![CDATA[
    /// Attach to stdin and keep it open
    /// --interactive
    /// ]]></summary>
    public bool Interactive { get; set; }

    /// <summary><![CDATA[
    /// Set metadata on an object
    /// --label
    /// ]]></summary>
    public IList<EnvValue> Label { get; set; } = [];

    /// <summary><![CDATA[
    /// Memory limit (e.g. 512M, 1G)
    /// --memory
    /// ]]></summary>
    public string? Memory { get; set; }

    /// <summary><![CDATA[
    /// Name of the container
    /// --name
    /// ]]></summary>
    public string? Name { get; set; }

    /// <summary><![CDATA[
    /// Connect a container to a network
    /// --network
    /// ]]></summary>
    public string? Network { get; set; }

    /// <summary><![CDATA[
    /// Add a network-scoped alias for the container
    /// --network-alias
    /// ]]></summary>
    public string? NetworkAlias { get; set; }

    /// <summary><![CDATA[
    /// Disable any container-specified health check
    /// --no-healthcheck
    /// ]]></summary>
    public bool NoHealthcheck { get; set; }

    /// <summary><![CDATA[
    /// Publish a port from a container to host
    /// --publish
    /// ]]></summary>
    public IList<PortMap> Publish { get; set; } = [];

    /// <summary><![CDATA[
    /// Publish all exposed ports to random host ports
    /// --publish-all
    /// ]]></summary>
    public bool PublishAll { get; set; }

    /// <summary><![CDATA[
    /// Remove the container after it stops
    /// --rm
    /// ]]></summary>
    public bool RM { get; set; }

    /// <summary><![CDATA[
    /// Size of /dev/shm (e.g. 64M, 1G)
    /// --shm-size
    /// ]]></summary>
    public string? ShmSize { get; set; }

    /// <summary><![CDATA[
    /// Signal to stop the container
    /// --stop-signal
    /// ]]></summary>
    public string? StopSignal { get; set; }

    /// <summary><![CDATA[
    /// Timeout (in seconds) to stop the container before killing it (-1 for no timeout)
    /// --stop-timeout
    /// ]]></summary>
    public int? StopTimeout { get; set; }

    /// <summary><![CDATA[
    /// Mount tmpfs to the container at the given path
    /// --tmpfs
    /// ]]></summary>
    public string? Tmpfs { get; set; }

    /// <summary><![CDATA[
    /// Open a TTY with the container process.
    /// --tty
    /// ]]></summary>
    public bool TTY { get; set; }

    /// <summary><![CDATA[
    /// Ulimit options (format: <name>=<soft>[:<hard>], use -1 for unlimited)
    /// --ulimit
    /// ]]></summary>
    public string? ULimit { get; set; }

    /// <summary><![CDATA[
    /// User ID for the process (name|uid|uid:gid)
    /// --user
    /// ]]></summary>
    public string? User { get; set; }

    /// <summary><![CDATA[
    /// Bind mount a volume to the container
    /// --volume
    /// ]]></summary>
    public IList<VolumeArg> Volume { get; set; } = [];

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
        args.AddOptional("--health-cmd", HealthCmd);
        args.AddOptional("--health-interval", HealthInterval);
        args.AddOptional("--health-retries", HealthRetries);
        args.AddOptional("--health-start-period", HealthStartPeriod);
        args.AddOptional("--health-timeout", HealthTimeout);
        args.AddOptional("--hostname", Hostname);
        args.AddFlag("--interactive", Interactive);
        args.AddOptional("--label", Label);
        args.AddOptional("--memory", Memory);
        args.AddOptional("--name", Name);
        args.AddOptional("--network", Network);
        args.AddOptional("--network-alias", NetworkAlias);
        args.AddFlag("--no-healthcheck", NoHealthcheck);
        args.AddOptional("--publish", Publish);
        args.AddFlag("--publish-all", PublishAll);
        args.AddFlag("--rm", RM);
        args.AddOptional("--shm-size", ShmSize);
        args.AddOptional("--stop-signal", StopSignal);
        args.AddOptional("--stop-timeout", StopTimeout);
        args.AddOptional("--tmpfs", Tmpfs);
        args.AddFlag("--tty", TTY);
        args.AddOptional("--ulimit", ULimit);
        args.AddOptional("--user", User);
        args.AddOptional("--volume", Volume);
        args.AddOptional("--workdir", Workdir);
        args.Add(Image);
        args.AddOptional(Command);
        args.AddOptional(Arguments);
    }

}
