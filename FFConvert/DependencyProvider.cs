// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Infrastructure;
using FFConvert.Interfaces;

namespace FFConvert;

internal sealed class DependencyProvider
{
    public IConsole Console { get; }
    public IImplementationsOf<IConverter> Converters { get; }
    public IImplementationsOf<IValidator> Validators { get; }
    public IProgressReport ProgressReporter { get; }
    public IFFMpegRunner FFMpegRunner { get; }

    public ICallbackProvider CallbackProvider { get; }

    public ProgramConfiguration Configuration { get; }

    public bool ConfigHasBeenCreated { get; private set; }

    public DependencyProvider()
    {
        Configuration = LoadConfig();
        Console = new ProgramConsole();
        Converters = new ImplementationsOf<IConverter>();
        Validators = new ImplementationsOf<IValidator>();
        ProgressReporter = new ProgressReporter(Console);
        FFMpegRunner = new FFMpegRunner(Configuration);
        CallbackProvider = new CallbackProvider();
    }

    private ProgramConfiguration LoadConfig()
    {
        var manager = new ConfigManager();
        if (manager.ConfigExists)
        {
            return manager.Load();
        }
        else
        {
            var @default = new ProgramConfiguration();
            manager.Save(@default);
            ConfigHasBeenCreated = true;
            return @default;
        }
    }
}
