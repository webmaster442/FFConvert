
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class CommandLineToConsole : BaseStep
{
    private readonly IConsole _console;

    public CommandLineToConsole(IConsole console)
    {
        _console = console;
    }

    public override bool CanSkip(State state)
    {
        return
            !state.Arguments.IsSwitchPresent(Constants.SwitchOutputToSh)
            && !state.Arguments.IsSwitchPresent(Constants.SwitchOutputToBat)
            && !state.Arguments.IsSwitchPresent(Constants.SwithOuputToPs);
    }

    public override bool TryExecute(State state)
    {

        if (!state.Configuration.TryGetFFmpeg(out string ffmpegPath))
        {
            AddIssue(Resources.ErrorFFmpegNotFound, state.Configuration.FFMpegDir);
            return false;
        }

        WriteHeader(state.Arguments);

        foreach (var commandLine in state.CreatedCommandLines)
        {
            string line = $"{ffmpegPath} {commandLine.CommandLine}";
            _console.WriteLine(line);
        }

        return true;
    }

    private void WriteHeader(Arguments arguments)
    {
        if (arguments.IsSwitchPresent(Constants.SwitchOutputToSh))
        {
            _console.WriteLine("#!/bin/bash");
        }
    }
}
