// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Domain;

internal sealed class FFMpegOutput
{
    public float Bitrate { get; set; }
    public long FileSize { get; set; }
    public TimeSpan Time { get; set; }
    public float Speed { get; set; }
}
