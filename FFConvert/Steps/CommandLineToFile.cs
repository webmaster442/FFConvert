// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------


using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class CommandLineToFile : BaseStep
{
    private readonly IConsole _console;

    public CommandLineToFile(IConsole console)
    {
        _console = console;
    }

    public override bool CanSkip(State state)
    {
        return
            !state.Arguments.TryGetSwitchWithValue(Constants.SwitchOutputToSh, out _);
    }

    public override bool TryExecute(State state)
    {
        if (!state.Configuration.TryGetFFmpeg(out string ffmpegPath))
        {
            AddIssue(Resources.ErrorFFmpegNotFound, state.Configuration.FFMpegDir);
            return false;
        }

        if (!state.Arguments.TryGetSwitchWithValue(Constants.SwitchOutputToSh, out string file))
        {
            AddIssue(Resources.ErrorGeneral);
            return false;
        }

        try
        {
            using (var writer = File.AppendText(file))
            {
                foreach (var commandLine in state.CreatedCommandLines)
                {
                    string line = $"{ffmpegPath} {commandLine.CommandLine}";
                    writer.WriteLine(line);
                }
            }
        }
        catch (IOException ex)
        {
            AddIssue(ex.Message);
        }

        return AreNoIssues();
    }
}
