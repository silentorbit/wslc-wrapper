namespace SilentOrbit.WSLC.Extensions;

static class ListExtension
{
    extension(List<string> list)
    {
        public void AddRange(params string[] args)
        {
            list.AddRange(args);
        }

        public void AddOptional(string? value)
        {
            if (value == null)
                return;
            list.Add(value);
        }

        public void AddOptional(string key, string? value)
        {
            if (value == null)
                return;
            list.AddRange(key, value);
        }

        public void AddOptional(string key, int? value)
        {
            if (value == null)
                return;
            list.AddRange(key, value.Value.ToString());
        }

        public void AddFlag(string key, bool value)
        {
            if (value)
                list.Add(key);
        }

        public void AddOptional(IEnumerable<string>? values)
        {
            if (values == null)
                return;

            list.AddRange(values);
        }

        public void AddOptional(string key, IEnumerable<IListArg>? values)
        {
            if (values == null)
                return;

            foreach (var value in values)
                list.AddRange(key, value.BuildArg());
        }

        public void AddOptional(string key, IDictionary<string, string>? values)
        {
            if (values == null)
                return;

            foreach (var value in values)
                list.AddRange(key, $"{value.Key}={value.Value}");
        }
    }
}
