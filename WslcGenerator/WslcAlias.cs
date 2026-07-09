namespace SilentOrbit.WSLC;

/// <summary>
/// All alias documents
/// </summary>
class WslcAlias
{
    public static bool IsAlias(IEnumerable<string> args) => IsAlias(string.Join("-", args));

    public static bool IsAlias(string cmd) => GetAlias(cmd) != cmd;

    public static string GetAlias(string cmd) => cmd switch
    {
        "login" => "registry-login",
        "logout" => "registry-logout",

        "build" => "image-build",
        "images" => "image-list",
        "import" => "image-import",
        "load" => "image-load",
        "pull" => "image-pull",
        "push" => "image-push",
        "rmi" => "image-rmi",
        "save" => "image-save",
        "tag" => "image-tag",

        "attach" => "container-attach",
        "create" => "container-create",
        "exec" => "container-exec",
        "export" => "container-export",
        "inspect" => "container-inspect",
        "kill" => "container-kill",
        "logs" => "container-logs",
        "list" => "container-list",
        "remove" => "container-remove",
        "run" => "container-run",
        "start" => "container-start",
        "stats" => "container-stats",
        "stop" => "container-stop",

        _ => cmd
    };
}
