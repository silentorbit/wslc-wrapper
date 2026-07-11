
# WSL Container Wrapper

A wrapper for the wslc.exe command.

Offers a stronly typed interface to generate commands to manage containers on Windows.

# Usage

Reference the WslcWrapper.csproj or use the NuGet package [SilentOrbit.WSLC](https://www.nuget.org/packages/SilentOrbit.WSLC).

# Sample

```C#
//Get list of images
List<ImageInfo> list = new ImageList().RunJson();

//Create a container from one of the images
new ContainerCreate(image: list[0])
{
    Name = "Hello",
    RM = true, //--rm: Remove the container after it stops
}.Run().ExpectOK();

//Start the new container
var resp = new ContainerStart(containerid: "Hello").Run().ExpectOK();
//Inspect the results
Console.WriteLine($"Result: {resp.ExitCode}");
Console.WriteLine($"Output: {resp.StdOut}");
Console.Error.WriteLine($"Error: {resp.StdErr}");
```