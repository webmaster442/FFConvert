using FFConvert;
using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Infrastructure;
using FFConvert.Properties;
using FFConvert.Steps;

try
{
    Arguments arguments = new(args);
    PresetManager presetManager = new();
    DependencyProvider dependencies = new();

    var console = dependencies.Console;

    if (!presetManager.PresetsExits)
    {
        presetManager.CreateSamplePreset();
        console.Error(Resources.ErrorPresetsFileNotExists);
        return;
    }

    if (!presetManager.TryLoadPresets(out Preset[]? presets))
    {
        console.Error(Resources.ErrorCoudNotLoadPresets);
        return;
    }

    HelpGenerator helpGenerator = new(presets);

    if (arguments.IsGenericHelpRequested())
    {
        string msg = helpGenerator.GetGenericHelp();
        console.WriteLine(msg);
        return;
    }
    else if (arguments.IsSpecificHelpRequested())
    {
        string msg = helpGenerator.GetHelp(arguments.PresetName);
        console.WriteLine(msg);
        return;
    }

    using StepRunner runner = new(dependencies.Console,
                                  new CheckFFmpegInstallation(),
                                  new CollectInputFiles(),
                                  new PresetValidation(dependencies.Converters, dependencies.Validators),
                                  new GetPresetArguments(dependencies.Converters, dependencies.Validators, dependencies.Console),
                                  new CreateCommandLines(),
                                  new Encode(dependencies.FFMpegRunner, dependencies.Console, dependencies.ProgressReporter));

    State state = new State(presets, dependencies.Configuration, arguments);

    runner.Run(state);
}
catch (Exception ex)
{
    Console.WriteLine("Fatal error");
    Console.WriteLine(ex.Message);
}