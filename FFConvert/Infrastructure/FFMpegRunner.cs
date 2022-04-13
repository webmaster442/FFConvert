using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace FFConvert.Infrastructure;

internal class FFMpegRunner : IFFMpegRunner
{
    public event EventHandler<FFMpegOutput>? ProgressReporter;
    private readonly List<string> _currentCapture;
    private readonly string _ffmpegExe;
    private readonly string _ffprobeExe;

    public FFMpegRunner(ProgramConfiguration configuration)
    {
        _currentCapture = new List<string>(15);

        bool success = configuration.TryGetFFmpeg(out _ffmpegExe);
        if (!success)
            throw new InvalidOperationException();

        success = configuration.TryGetFFProbe(out _ffprobeExe);
        if (!success)
            throw new InvalidOperationException();
    }

    public async Task<FFProbeResult> Probe(FFMpegCommand command, CancellationToken cancellationToken)
    {
        using Process process = new();
        process.StartInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            FileName = _ffprobeExe,
            Arguments = $"-v quiet -print_format json -show_format {command.InputFile}"
        };
        process.Start();
        string json = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync(cancellationToken);

        return JsonSerializer.Deserialize<FFProbeResult>(json) ?? new FFProbeResult();

    }

    public async Task Run(FFMpegCommand command, CancellationToken cancellationToken)
    {
        using Process process = new();
        process.StartInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            FileName = _ffmpegExe,
            Arguments = $"-progress - -v warning -hide_banner {command.CommandLine}"
        };
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OnOutputDataRecieved;
        _currentCapture.Clear();
        process.Start();
        process.BeginOutputReadLine();
        await process.WaitForExitAsync(cancellationToken);
    }

    private void OnOutputDataRecieved(object sender, DataReceivedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Data) && !e.Data.StartsWith("progress="))
        {
            _currentCapture.Add(e.Data);
        }
        else
        {
            FFMpegOutput output = FFMpegOutputParser.Parse(_currentCapture);
            ProgressReporter?.Invoke(this, output);
            _currentCapture.Clear();
        }
    }
}
