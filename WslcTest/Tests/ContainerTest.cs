using SilentOrbit.WSLC.Commands;

namespace SilentOrbit.WSLC.Tests;

[TestClass]
public sealed class ContainerTest
{
    [TestMethod]
    public void Attach()
    {
        var args = new ContainerAttach("id").BuildArgs();
        AssertList.AreEqual(["container", "attach", "id"], args);

        args = new ContainerAttach { ContainerID = "id" }.BuildArgs();
        AssertList.AreEqual(["container", "attach", "id"], args);
    }

    [TestMethod]
    public void Create()
    {
        var args = new ContainerCreate("my-image")
        {
            Name = "container-name"
        }.BuildArgs();
        AssertList.AreEqual(["container", "create", "--name", "container-name", "my-image"], args);
    }

#if DEBUG
    /// <summary>
    /// This test is only testing against existing containers.
    /// </summary>
    [TestMethod]
    public void ListInspect()
    {
        var list = new ContainerList() { All = true }.RunJson();
        foreach (var item in list)
        {
            var inspect = new ContainerInspect(item.Name).RunJson();
        }
        Assert.IsTrue(true);
    }
#endif
}
