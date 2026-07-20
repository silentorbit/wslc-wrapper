using SilentOrbit.WSLC.Commands;
using SilentOrbit.WSLC.Docker;

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

        var create = new ContainerCreate() { Image = "hello-world" };
        var containerId = WslcExe.RunString(create);
        try
        {
            var inspect = WslcExe.RunJson(new ContainerInspect(containerId));
            Assert.HasCount(1, inspect);
            var inspectedContainer = inspect[0];
            Assert.AreEqual(ContainerStateStatus.Created, inspectedContainer.State.Status);
        }
        finally
        {
            var remove = new ContainerRemove(containerId) { Force = true };
            var removed = WslcExe.RunString(remove);
            Assert.AreEqual(containerId, removed);
        }
    }

#if DEBUG
    /// <summary>
    /// This test is only testing against existing containers.
    /// </summary>
    [TestMethod]
    public void ListInspect()
    {
        var list = WslcExe.RunJson(new ContainerList() { All = true });
        foreach (var item in list)
        {
            var inspect = new ContainerInspect(item.Name).RunJson();
        }
    }
#endif
}
