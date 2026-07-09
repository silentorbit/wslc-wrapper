namespace SilentOrbit.WSLC.Commands;

public partial class ContainerCreate : WslcCommand
{
    [SetsRequiredMembers]
    public ContainerCreate(ImageListJson image, string? command = null, params IList<string> arguments)
    {
        this.Image = image.RepositoryOrId;
        this.Command = command;
        this.Arguments = arguments;
    }
}
