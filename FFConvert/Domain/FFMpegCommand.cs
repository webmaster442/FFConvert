namespace FFConvert.Domain;

public class FFMpegCommand
{
    public string CommandLine { get; init; }
    public string OutputFile { get; init; }
    public string InputFile { get; init; }

    public FFMpegCommand()
    {
        InputFile = string.Empty;
        CommandLine = string.Empty;
        OutputFile = string.Empty;
    }
}
