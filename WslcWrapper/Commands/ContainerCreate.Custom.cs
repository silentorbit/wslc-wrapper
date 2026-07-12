namespace SilentOrbit.WSLC.Commands;

public partial class ContainerCreate : WslcCommand
{
    /// <summary><![CDATA[
    /// Creates a container.
    /// Usage: wslc container create [<options>] <image> [<command>] [<arguments>...]
    /// ]]></summary>
    /// <param name="image">Image name</param>
    /// <param name="command">The command to run</param>
    /// <param name="arguments">Arguments to pass to container's init process</param>
    [SetsRequiredMembers]
    public ContainerCreate(ImageListItem image, string? command = null, params IList<string> arguments)
    {
        this.Image = image.RepositoryOrId;
        this.Command = command;
        this.Arguments = arguments;
    }
}
