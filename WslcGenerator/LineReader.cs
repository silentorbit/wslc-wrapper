using System.Diagnostics;

namespace SilentOrbit.WSLC;

internal class LineReader(string output)
{
    readonly IEnumerator<string> enumerator = ((IEnumerable<string>)output.Replace("\r\n", "\n").Split('\n')).GetEnumerator();

    public override string ToString() => output;

    public string ReadLine()
    {
        if (enumerator.MoveNext() == false)
            throw new EndOfStreamException();
        return enumerator.Current;
    }

    public IEnumerable<string> ReadLines()
    {
        while (true)
        {
            var line = ReadLine();
            if (line == "")
                yield break;
            else
                yield return line;
        }
    }

    public void ExpectLine(string expect = "")
    {
        var line = ReadLine();
        Debug.Assert(line == expect);
        if (line != expect)
            throw new Exception();
    }

    public void ExpectEnd()
    {
        if (enumerator.MoveNext() == false)
            return;

        throw new Exception("Expected end of stream, got " + enumerator.Current);
    }
}
