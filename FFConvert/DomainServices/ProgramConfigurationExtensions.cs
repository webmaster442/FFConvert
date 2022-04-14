// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using System.Runtime.InteropServices;

namespace FFConvert.DomainServices;

internal static class ProgramConfigurationExtensions
{
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static bool TryGetFFmpeg(this ProgramConfiguration configuration, out string ffmpegPath)
    {
        string ffmpegName = IsWindows() ? "ffmpeg.exe" : "ffmpeg";
        ffmpegPath = Path.Combine(configuration.FFMpegDir, ffmpegName);
        return File.Exists(ffmpegPath);
    }

    public static bool TryGetFFProbe(this ProgramConfiguration configuration, out string ffprobePath)
    {
        string ffprobeName = IsWindows() ? "ffprobe.exe" : "ffprobe";
        ffprobePath = Path.Combine(configuration.FFMpegDir, ffprobeName);
        return File.Exists(ffprobePath);
    }
}
