namespace FFConvert.Domain;

public sealed class ProgramConfiguration
{
    public string FFMpegDir { get; set; }

    public ProgramConfiguration()
    {
        FFMpegDir = AppDomain.CurrentDomain.BaseDirectory;
    }
}
