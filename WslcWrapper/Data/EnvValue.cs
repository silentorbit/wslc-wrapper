namespace SilentOrbit.WSLC.Data;

/// <summary>
/// <see cref="ContainerCreate.Env"/>
/// </summary>
public class EnvValue : IListArg
{
    public required string Key { get; set; }
    public required string Value { get; set; }

    public EnvValue() { }

    [SetsRequiredMembers]
    public EnvValue(string key, string value)
    {
        this.Key = key;
        this.Value = value;
    }

    public static implicit operator EnvValue(string value)
    {
        var parts = value.Split('=', 2);
        return new EnvValue
        {
            Key = parts[0],
            Value = parts[1]
        };
    }

    public static implicit operator string(EnvValue env) => env.BuildArg();

    public string BuildArg()
    {
        return $"{Key}={Value}";
    }

    public override string ToString() => BuildArg();
}
