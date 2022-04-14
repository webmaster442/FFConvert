using FFConvert.Domain;
using FFConvert.Infrastructure;
using FFConvert.Interfaces;
using System.Text;
using System.Xml;
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

    public bool ConfigHasBeenCreated { get; private set; }

    private ProgramConfiguration GetConfiguration()
    {
        string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(ProgramConfiguration));
        if (!File.Exists(configFile))
        {
            using XmlTextWriter writer = new(configFile, encoding: Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            serializer.Serialize(writer, new ProgramConfiguration());
            ConfigHasBeenCreated = true;
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
