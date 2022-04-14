// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Domain;

public sealed class ProgramConfiguration
{
    public string FFMpegDir { get; set; }

    public ProgramConfiguration()
    {
        FFMpegDir = AppDomain.CurrentDomain.BaseDirectory;
    }
}
