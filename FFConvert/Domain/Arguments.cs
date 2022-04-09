namespace FFConvert.Domain;

internal sealed class Arguments
{
    private readonly string[] _arguments;

    public int Count => _arguments.Length;
    public string FileName => _arguments.Length >= 1 ? _arguments[0] : string.Empty;
    public string PresetName => _arguments.Length >= 2 ? _arguments[1] : string.Empty;
    public string OutputDirectory => _arguments.Length >= 3 ? _arguments[2] : string.Empty;

    public Arguments(string[] arguments)
    {
        _arguments = arguments;
    }
}
