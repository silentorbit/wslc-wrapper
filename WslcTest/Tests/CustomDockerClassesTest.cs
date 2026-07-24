using SilentOrbit.WSLC.Docker;

namespace SilentOrbit.WSLC.Tests;

[TestClass]
public sealed class CustomDockerClassesTest
{
    [TestMethod]
    public void ManuallyEditedClasses()
    {
        Assert.IsTrue(typeof(ImageConfig).GetProperty(nameof(ImageConfig.ExposedPorts))!.PropertyType == typeof(IDictionary<string, ExposedPort>));
        Assert.IsTrue(typeof(ContainerConfig).GetProperty(nameof(ContainerConfig.ExposedPorts))!.PropertyType == typeof(IDictionary<string, ExposedPort>));
        Assert.IsTrue(typeof(ContainerConfig).GetProperty(nameof(ContainerConfig.Volumes))!.PropertyType == typeof(IDictionary<string, ContainerVolume>));
    }
}
