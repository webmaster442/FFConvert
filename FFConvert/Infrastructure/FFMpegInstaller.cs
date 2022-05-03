// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Diagnostics;

using FFConvert.Domain;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Infrastructure;

internal sealed class FFMpegInstaller : IDisposable
{
    private readonly IConsole _console;
    private readonly string _updateFile;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public FFMpegInstaller(IConsole console, string file = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-full.7z")
    {
        _console = console;
        _updateFile = file;
        _cancellationTokenSource = new CancellationTokenSource();
    }
    private async Task Install(CancellationToken token)
    {
        var targetFile = Path.Combine(Path.GetTempPath(), "ffmpeg.7z");
        try
        {
            _console.WriteLine("Downloading...");
            using var client = new HttpClient();
            using var s = await client.GetStreamAsync(_updateFile, token);
            using var fs = File.Create(targetFile);
            await s.CopyToAsync(fs, token);
            fs.Close();

            _console.WriteLine("Extracting...");
            await Extract(targetFile, AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe", token);
            await Extract(targetFile, AppDomain.CurrentDomain.BaseDirectory, "ffprobe.exe", token);

            _console.WriteLine("Configuring...");
            SetConfig(AppDomain.CurrentDomain.BaseDirectory);

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
        _console.CancelEvent += OnCancel;
        Install(_cancellationTokenSource.Token).Wait();
        _console.CancelEvent -= OnCancel;
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

    private static void SetConfig(string baseDirectory)
    {
        var manager = new ConfigManager();
        manager.Save(new ProgramConfiguration
        {
            FFMpegDir = baseDirectory,
        });
    }

    public void Dispose()
    {
        _cancellationTokenSource.Dispose();
        _console.CancelEvent -= OnCancel;
    }

    private void OnCancel(object? sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel();
    }
}
