namespace SilentOrbit.WSLC.Commands;

/// <summary><![CDATA[
/// Creates a non-persistent session with the given storage path and opens a shell into it. The session is deleted when the shell exits. If no name is provided, a GUID is generated and printed to stderr.
/// Usage: wslc system session enter [<options>] <storage-path>
/// ]]></summary>
[GeneratedCode("WslcGenerator", "0.0.0.1")]
public partial class SystemSessionEnter : WslcCommand
{
    /// <summary>
    /// Path to the session storage directory
    /// </summary>
    public required string StoragePath { get; set; }

    /// <summary><![CDATA[
    /// Creates a non-persistent session with the given storage path and opens a shell into it. The session is deleted when the shell exits. If no name is provided, a GUID is generated and printed to stderr.
    /// Usage: wslc system session enter [<options>] <storage-path>
    /// ]]></summary>
    public SystemSessionEnter() { }

    /// <summary><![CDATA[
    /// Creates a non-persistent session with the given storage path and opens a shell into it. The session is deleted when the shell exits. If no name is provided, a GUID is generated and printed to stderr.
    /// Usage: wslc system session enter [<options>] <storage-path>
    /// ]]></summary>
    /// <param name="storage_path">Path to the session storage directory</param>
    [SetsRequiredMembers]
    public SystemSessionEnter(string storage_path)
    {
        this.StoragePath = storage_path;
    }

    /// <summary><![CDATA[
    /// Name for the session. If not provided, a GUID is generated.
    /// --name
    /// ]]></summary>
    public string? Name { get; set; }

    /// <summary>
    /// Return arguments for wslc.exe
    /// </summary>
    protected override void BuildArgs(List<string> args)
    {
        args.AddRange("system", "session", "enter");
        args.AddOptional("--name", Name);
        args.Add(StoragePath);
    }

}
