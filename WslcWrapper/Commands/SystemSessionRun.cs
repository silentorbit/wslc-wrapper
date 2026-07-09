namespace SilentOrbit.WSLC.Commands;

/// <summary>
/// Runs a command in an active session without a TTY. The command and its arguments are forwarded directly to the session. If no session is specified, the wslc default session will be used.
/// Usage: wslc system session run [<options>] <command> [<arguments>...]
/// </summary>
public partial class SystemSessionRun : WslcCommand
{
    public required string Command { get; set; }

    public required IList<string> Arguments { get; set; }

    public SystemSessionRun() { }

    [SetsRequiredMembers]
    public SystemSessionRun(string command, params IList<string> arguments)
    {
        this.Command = command;
        this.Arguments = arguments;
    }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "run");
        args.Add(Command);
        args.AddRange(Arguments);
    }

}
