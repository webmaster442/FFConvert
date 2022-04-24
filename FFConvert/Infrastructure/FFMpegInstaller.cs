
using FFConvert.Interfaces;

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

    public async Task Install(CancellationToken token)
    {
        var targetFile = Path.Combine(Path.GetTempPath(), "ffmpeg.7z");
        try
        {
            using var client = new HttpClient();
            using var s = await client.GetStreamAsync(_updateFile, token);
            using var fs = File.Create(targetFile);
            await s.CopyToAsync(fs, token);



        }
        catch (Exception ex)
        {

        }
    }
}
