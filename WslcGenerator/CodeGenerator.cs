using System.Diagnostics;
using System.Text;

namespace SilentOrbit.WSLC;

class CodeGenerator
{
    readonly StringBuilder s = new();
    public override string ToString()
    {
        Debug.Assert(indentCount == 0);
        return s.ToString();
    }

    int indentCount
    {
        get => field;
        set
        {
            Debug.Assert(field - 1 <= value && value <= field + 1);
            field = value;
            if (value < 0)
                indent = $"#error INVALIDINDENT: {value}";
            else
                indent = new string(' ', value * 4);
        }
    } = 0;

    string indent = "";
    bool indentSingleLine = false;

    internal void AppendLine() => s.AppendLine();

    internal void AppendLine(string line)
    {
        if (line == "}")
        {
            indentCount -= 1;
        }

        s.AppendLine($"{indent}{line}");

        if (indentSingleLine)
        {
            indentCount -= 1;
            indentSingleLine = false;
        }

        if (line == "{")
        {
            indentCount += 1;
        }
        if (line.StartsWith("if ") || line.StartsWith("foreach "))
        {
            indentSingleLine = true;
            indentCount += 1;
        }

    }

}
