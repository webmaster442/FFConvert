using FFConvert.Domain;
using FFConvert.Infrastructure;
using FFConvert.Interfaces;
using System.Xml.Serialization;

namespace FFConvert;

internal sealed class DependencyProvider
{
    public IConsole Console { get; }
    public IImplementationsOf<IConverter> Converters { get; }
    public IImplementationsOf<IValidator> Validators { get; }
    public IProgressReport ProgressReporter { get; }
    public IFFMpegRunner FFMpegRunner { get; }

    public ProgramConfiguration Configuration { get; }

    private static ProgramConfiguration GetConfiguration()
    {
        string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(ProgramConfiguration));
        if (!File.Exists(configFile))
        {
            using var configWrite = File.Create(configFile);
            serializer.Serialize(configWrite, new ProgramConfiguration());
            return new ProgramConfiguration();
        }

        using var configRead = File.OpenRead(configFile);
        var result = (ProgramConfiguration?)serializer.Deserialize(configRead);
        return result!;
    }

    public DependencyProvider()
    {
        Configuration = GetConfiguration();
        Console = new ProgramConsole();
        Converters = new ImplementationsOf<IConverter>();
        Validators = new ImplementationsOf<IValidator>();
        ProgressReporter = new ProgressReporter(Console);
        FFMpegRunner = new FFMpegRunner(Configuration);
    }
}
