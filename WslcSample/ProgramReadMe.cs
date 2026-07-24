namespace SilentOrbit.WSLC;

internal class ProgramReadMe
{
    static void Main(string[] args)
    {
        //Get list of images
        List<ImageListItem> list = new ImageList().RunJson();

        //Create a container from one of the images
        var containerID = new ContainerCreate(image: list[0])
        {
            Name = "Hello",
            RM = true, //--rm: Remove the container after it stops
        }.RunID();

        //Start the new container
        var resp = new ContainerStart(containerID).Run();

        //Inspect the results
        Console.WriteLine($"Result: {resp.ExitCode}");
        Console.WriteLine($"Output: {resp.StdOut}");
        Console.Error.WriteLine($"Error: {resp.StdErr}");
    }
}
