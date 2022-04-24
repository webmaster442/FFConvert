// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using FFConvert.Domain;

namespace FFConvert.Infrastructure;

internal class PresetManager
{
    private readonly XmlSerializer _serializer;
    private readonly string _file;

    public PresetManager()
    {
        var root = new XmlRootAttribute("Presets");
        root.Namespace = "my://presets";
        _serializer = new XmlSerializer(typeof(Preset[]), root);
        _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets.xml");
    }

    public bool TryLoadPresets([NotNullWhen(true)] out Preset[]? presets)
    {
        try
        {
            using var stream = File.OpenRead(_file);
            presets = (Preset[]?)_serializer.Deserialize(stream);
            return presets != null;
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


        try
        {
            string sampleName = Path.ChangeExtension(_file, ".sample.xml");

            using XmlTextWriter writer = new(sampleName, encoding: Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            _serializer.Serialize(writer, new Preset[] { sample });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
