// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Diagnostics;

using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Infrastructure;

internal class FFMpegInstaller
{
    private readonly IConsole _console;
    private readonly string _updateFile;

    public FFMpegInstaller(IConsole console, string file = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-full.7z")
    {
        _console = console;
        _updateFile = file;
    }
    private async Task Install(CancellationToken token)
    {
        var targetFile = Path.Combine(Path.GetTempPath(), "ffmpeg.7z");
        try
        {
            using var client = new HttpClient();
            using var s = await client.GetStreamAsync(_updateFile, token);
            using var fs = File.Create(targetFile);
            await s.CopyToAsync(fs, token);

            await Extract(targetFile, AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe", token);
            await Extract(targetFile, AppDomain.CurrentDomain.BaseDirectory, "ffprobe.exe", token);

        }
        catch (OperationCanceledException)
        {
            _console.Error(Resources.ErrorInstallAbort);
        }
        catch (Exception ex)
        {
            _console.Error(ex.Message);
        }
        Cleanup(targetFile);
    }

    public void StartInstall()
    {

    }

    private static void Cleanup(string ffmpegArchive)
    {
        if (File.Exists(ffmpegArchive))
            File.Delete(ffmpegArchive);
    }

    private static async Task Extract(string ffmpegArchive, string programDirectory, string fileName, CancellationToken token)
    {
        using var process = new Process();
        process.StartInfo.FileName = Path.Combine(programDirectory, Constants.SevenZipBin);
        process.StartInfo.Arguments = $"e {ffmpegArchive} -o\"{programDirectory}\" {fileName} -r -y";
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        await process.WaitForExitAsync(token);
    }
}
