namespace FFConvert.Domain;

internal sealed class ParameterKey : IEquatable<ParameterKey?>
{
    public string Name { get; init; }
    public bool IsOptional { get; init; }

    public ParameterKey(string name, bool isOptional)
    {
        Name = name;
        IsOptional = isOptional;
    }

    public ParameterKey(PresetParameter parameter)
    {
        Name = parameter.ParameterName;
        IsOptional = parameter.IsOptional;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ParameterKey);
    }

    public bool Equals(ParameterKey? other)
    {
        return other != null &&
               Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public static bool operator ==(ParameterKey? left, ParameterKey? right)
    {
        return EqualityComparer<ParameterKey>.Default.Equals(left, right);
    }

    public static bool operator !=(ParameterKey? left, ParameterKey? right)
    {
        return !(left == right);
    }
}
