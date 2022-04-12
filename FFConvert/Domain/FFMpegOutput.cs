namespace FFConvert.Domain;

internal sealed record class FFMpegOutput
{
    public float Bitrate { get; set; }
    public long FileSize { get; set; }
    public TimeSpan Time { get; set; }
    public float Speed { get; set; }
}
