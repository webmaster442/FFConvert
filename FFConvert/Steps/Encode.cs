// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.FFProbe;
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

    public override bool CanSkip(State state)
    {
        return
            state.Arguments.IsSwitchPresent(Constants.SwitchOutputToSh)
            || state.Arguments.IsSwitchPresent(Constants.SwitchOutputToBat)
            || state.Arguments.IsSwitchPresent(Constants.SwithOuputToPs);
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
        if (_tokenSource == null)
            throw new ObjectDisposedException(nameof(_tokenSource));

        var t = TryExecuteAsync(state.CreatedCommandLines, _tokenSource.Token);
        t.Wait();
        return t.Result;
    }

    private async Task<bool> TryExecuteAsync(IEnumerable<FFMpegCommand> commands, CancellationToken token)
    {
        try
        {
            foreach (var commandLine in commands)
            {
                token.ThrowIfCancellationRequested();
                   
                if (File.Exists(commandLine.OutputFile))
                {
                    _console.WriteLine($"Skipping {commandLine.OutputFile}");
                    continue;
                }

                _console.WriteLine($"Probing: {commandLine.InputFile}...");

                var probe  = await _fFMpegRunner.Probe(commandLine, token);
                _currentFileTime = FFProbeParser.GetDuration(probe);

                _console.WriteLine($"Encoding: {commandLine.InputFile}...");
                _progressReport.Show();
                _currentFile = commandLine.OutputFile;

                await _fFMpegRunner.Run(commandLine, token);
                _progressReport.Hide();
            }
            return true;
        }
        catch (OperationCanceledException)
        {
            _progressReport.Hide();
            AddIssue(Resources.ErrorAborted);
            return false;
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
