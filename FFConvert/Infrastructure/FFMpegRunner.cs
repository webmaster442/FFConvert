// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Diagnostics;

using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.FFProbe;
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

internal class FFMpegRunner : IFFMpegRunner
{
    public event EventHandler<FFMpegOutput>? ProgressReporter;
    private readonly List<string> _currentCapture;
    private readonly string _ffmpegExe;
    private readonly string _ffprobeExe;
    private readonly bool _ffmpegInstallOk;

    public FFMpegRunner(ProgramConfiguration configuration)
    {
        _currentCapture = new List<string>(15);

#pragma warning disable RCS1233
        // Intentionally not &&, because both sides needs to be evaluated
        // To not complain abut possible null for _ffprobeExe
        _ffmpegInstallOk = configuration.TryGetFFmpeg(out _ffmpegExe)
                        & configuration.TryGetFFProbe(out _ffprobeExe);
#pragma warning restore RCS1233
    }

    public async Task<FfprobeType> Probe(FFMpegCommand command, CancellationToken cancellationToken)
    {
        if (!_ffmpegInstallOk)
            throw new InvalidOperationException("Invalid config");

        using Process process = new();
        process.StartInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            FileName = _ffprobeExe,
            Arguments = $"-v quiet -show_format -print_format xml=fully_qualified=1 {command.InputFile}"
        };
        process.Start();
        string xml = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync(cancellationToken);

        return FFProbeParser.Parse(xml);

        //return JsonSerializer.Deserialize<FFProbeResult>(json) ?? new FFProbeResult();

    }

    public async Task Run(FFMpegCommand command, CancellationToken cancellationToken)
    {
        if (!_ffmpegInstallOk)
            throw new InvalidOperationException("Invalid config");

        using Process process = new();
        process.StartInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            FileName = _ffmpegExe,
            Arguments = $"-progress - -v fatal -hide_banner {command.CommandLine}"
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
