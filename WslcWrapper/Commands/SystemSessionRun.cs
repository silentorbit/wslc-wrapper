namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Runs a command in an active session without a TTY. The command and its arguments are forwarded directly to the session. If no session is specified, the wslc default session will be used.
/// Usage: wslc system session run [<options>] <command> [<arguments>...]
/// ]]></summary>
public partial class SystemSessionRun : WslcCommand
{
    /// <summary>
    /// The command to run
    /// </summary>
    public required string Command { get; set; }

    /// <summary>
    /// Arguments to pass to the command being run
    /// </summary>
    public IList<string>? Arguments { get; set; }

    /// <summary><![CDATA[
    /// Runs a command in an active session without a TTY. The command and its arguments are forwarded directly to the session. If no session is specified, the wslc default session will be used.
    /// Usage: wslc system session run [<options>] <command> [<arguments>...]
    /// ]]></summary>
    public SystemSessionRun() { }

    /// <summary><![CDATA[
    /// Runs a command in an active session without a TTY. The command and its arguments are forwarded directly to the session. If no session is specified, the wslc default session will be used.
    /// Usage: wslc system session run [<options>] <command> [<arguments>...]
    /// ]]></summary>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to the command being run</param>
    [SetsRequiredMembers]
    public SystemSessionRun(string command, params IList<string>? arguments)
    {
        this.Command = command;
        this.Arguments = arguments;
    }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "run");
        args.Add(Command);
        args.AddOptional(Arguments);
    }

}
