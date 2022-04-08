using FFConvert.Domain;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FFConvert.Infrastructure;

public class PresetManager
{
    private readonly XmlSerializer _serializer;
    private readonly string _file;

    public string PresetFile => _file;

    public PresetManager()
    {
        _serializer = new XmlSerializer(typeof(Preset[]), new XmlRootAttribute("Presets"));
        _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets.xml");
    }

    public bool TryLoadPresets(out Preset[] presets)
    {
        using var stream = File.OpenRead(_file);
        try
        {
            if (_serializer.Deserialize(stream) is Preset[] deserialized)
            {
                presets = deserialized;
                return true;
            }
            else
            {
                presets = Array.Empty<Preset>();
                return false;
            }
        }
        catch (Exception)
        {
            presets = Array.Empty<Preset>();
            return false;
        }
    }

    public bool PresetsExits
    {
        get
        {
            return File.Exists(_file);
        }
    }

    public bool CreateSamplePreset()
    {
        Preset sample = new Preset
        {
            Description = "Preset description",
            ActivatorName = "preset activator",
            CommandLine = "command line string",
            TargetExtension = ".mp4",
            ParametersToAsk = new List<PresetParameter>
        {
            new PresetParameter
            {
                ParameterDescription = "Description",
                ParameterName = "name",
            }
        }
        };

        string sampleName = Path.ChangeExtension(_file, ".sample.xml");

        using XmlTextWriter writer = new(sampleName, encoding: Encoding.UTF8);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 4;
        try
        {
            _serializer.Serialize(writer, new Preset[] { sample });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
