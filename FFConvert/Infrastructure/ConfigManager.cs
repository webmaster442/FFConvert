// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Text;
using System.Xml;
using System.Xml.Serialization;

using FFConvert.Domain;

namespace FFConvert.Infrastructure;

internal class ConfigManager
{
    private readonly string _configFile;
    private readonly XmlSerializer _serializer;

    public ConfigManager()
    {
        _configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
        _serializer = new XmlSerializer(typeof(ProgramConfiguration));
    }

    public bool ConfigExists => File.Exists(_configFile);

    public ProgramConfiguration Load()
    {
        using var configRead = File.OpenRead(_configFile);
        var result = (ProgramConfiguration?)_serializer.Deserialize(configRead);
        return result!;
    }

    public void Save(ProgramConfiguration configuration)
    {
        using XmlTextWriter writer = new(_configFile, encoding: Encoding.UTF8);
        writer.Formatting = Formatting.Indented;
        writer.Indentation = 4;
        _serializer.Serialize(writer, configuration);
    }
}
