namespace SilentOrbit.WSLC;

static class AssertList
{
    internal static void AreEqual(IList<string> expected, IList<string> actual)
    {
        var message = GetString(expected, actual);
        Assert.AreEqual(expected.Count, actual.Count, message);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }

    static string GetString(IList<string> expected, IList<string> actual)
    {
        var expectedString = string.Join(" ", expected);
        var actualString = string.Join(" ", actual);
        return $"Expected: {expectedString}, Actual: {actualString}";
    }
}
