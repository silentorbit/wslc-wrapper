namespace SilentOrbit.WSLC.Arguments;

public class VolumeArg : IListArg
{
    public required string HostPath { get; set; }
    public required string ContainerPath { get; set; }
    public bool ReadOnly { get; set; }

    public VolumeArg() { }

    public VolumeArg(string hostPath, string containerPath, bool readOnly = false)
    {
        this.HostPath = hostPath;
        this.ContainerPath = containerPath;
        this.ReadOnly = readOnly;
    }

    public static implicit operator VolumeArg(string arg)
    {
        var parts = arg.Split(':');
        var vol = new VolumeArg
        {
            HostPath = parts[0],
            ContainerPath = parts[1],
        };
        switch (parts.Length)
        {
            case 2:
                return vol;

            case 3:
                if (parts[2] == "ro")
                    vol.ReadOnly = true;
                else
                    throw new ArgumentException("Expected :ro, got " + arg);
                return vol;

            default:
                throw new NotImplementedException(arg);
        }
    }

    public static implicit operator string(VolumeArg map) => map.BuildArg();

    public string BuildArg()
    {
        if (ReadOnly)
            return $"{HostPath}:{ContainerPath}:ro";
        else
            return $"{HostPath}:{ContainerPath}";
    }

    public override string ToString() => BuildArg();
}
