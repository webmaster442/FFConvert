using FFConvert.Domain;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal sealed class Encode : BaseStep, IDisposable
{
    private readonly IFFMpegRunner _fFMpegRunner;
    private readonly IConsole _console;
    private readonly IProgressReport _progressReport;
    private double _currentFileTime;
    private string _currentFile;
    private CancellationTokenSource? _tokenSource;

    public Encode(IFFMpegRunner fFMpegRunner, IConsole console, IProgressReport progressReport)
    {
        _fFMpegRunner = fFMpegRunner;
        _console = console;
        _progressReport = progressReport;
        _fFMpegRunner.ProgressReporter += OnReportProgress;
        _console.CancelEvent += OnCancel;
        _currentFile = string.Empty;
        _tokenSource = new();
    }

    private void OnCancel(object? sender, EventArgs e)
    {
        _tokenSource?.Cancel();
    }

    private void OnReportProgress(object? sender, FFMpegOutput e)
    {
        _progressReport.Report(new ConvertProgress(_currentFileTime, _currentFile, e));
    }

    public override bool TryExecute(State state)
    {
        var t = TryExecuteAsync(state.CreatedCommandLines);
        t.Wait();
        return t.Result;
    }

    private async Task<bool> TryExecuteAsync(IEnumerable<FFMpegCommand> commands)
    {
        try
        {
            foreach (var commandLine in commands)
            {
                if (File.Exists(commandLine.OutputFile))
                {
                    _console.WriteLine($"Skipping {commandLine.OutputFile}");
                    continue;
                }

                _console.WriteLine($"Probing: {commandLine.InputFile}...");

                if (_tokenSource == null)
                    throw new ObjectDisposedException(nameof(_tokenSource));

                var result = await _fFMpegRunner.Probe(commandLine, _tokenSource.Token);
                _currentFileTime = result.Format.Duration - result.Format.StartTime;

                if (_tokenSource.IsCancellationRequested)
                {
                    AddIssue(Resources.ErrorAborted);
                    return false;
                }

                _console.WriteLine($"Encoding: {commandLine.InputFile}...");
                _progressReport.Show();
                _currentFile = commandLine.OutputFile;

                if (_tokenSource == null)
                    throw new ObjectDisposedException(nameof(_tokenSource));

                await _fFMpegRunner.Run(commandLine, _tokenSource.Token);
                _progressReport.Hide();

                if (_tokenSource.IsCancellationRequested)
                {
                    AddIssue(Resources.ErrorAborted);
                    return false;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            _progressReport.Hide();
            _console.Error(ex.Message);
            return false;
        }
    }

    public void Dispose()
    {
        if (_tokenSource != null)
        {
            _tokenSource.Dispose();
            _tokenSource = null;
        }
        _console.CancelEvent -= OnCancel;
        _fFMpegRunner.ProgressReporter -= OnReportProgress;
    }
}
