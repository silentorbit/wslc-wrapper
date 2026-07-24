namespace SilentOrbit.WSLC.Commands;

public class RawArguments : WslcCommand
{
    [SetsRequiredMembers]
    public RawArguments(params IList<string> args)
    {
        this.Arguments = args;
    }

    public required IList<string> Arguments { get; set; }

    protected override void BuildArgs(List<string> args)
    {
        args.AddRange(Arguments);
    }
}
