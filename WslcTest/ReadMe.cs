using SilentOrbit.WSLC.Commands;
using SilentOrbit.WSLC.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilentOrbit.WSLC;

internal class ReadMe
{
    public static void Demo()
    {
        //Get list of images
        List<ImageListItem> list = new ImageList().RunJson();
        
        //Create a container from one of the images
        new ContainerCreate(image: list[0])
        {
            Name = "Hello",
            RM = true, //--rm: Remove the container after it stops
        }.Run().ExpectOK();
        
        //Start the new container
        var resp = new ContainerStart(containerid: "Hello").Run();
        
        //Inspect the results
        Console.WriteLine($"Result: {resp.ExitCode}");
        Console.WriteLine($"Output: {resp.StdOut}");
        Console.Error.WriteLine($"Error: {resp.StdErr}");
    }
}
