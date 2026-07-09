using SilentOrbit.WSLC.Commands;

namespace SilentOrbit.WSLC.Tests;

[TestClass]
public sealed class ContainerTest
{
    [TestMethod]
    public void TestAttach()
    {
        var args = new ContainerAttach("id").BuildArgs();
        AssertList.AreEqual(["container", "attach", "id"], args);

        args = new ContainerAttach { ContainerID = "id" }.BuildArgs();
        AssertList.AreEqual(["container", "attach", "id"], args);
    }

    [TestMethod]
    public void TestCreate()
    {
        var args = new ContainerCreate("my-image")
        {
            Name = "container-name"
        }.BuildArgs();
        AssertList.AreEqual(["container", "create", "--name", "container-name", "my-image"], args);
    }
}
