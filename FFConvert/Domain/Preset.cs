// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Xml.Serialization;

namespace FFConvert.Domain;

[Serializable]
public sealed class Preset
{
    [XmlAttribute]
    public string ActivatorName { get; set; }
    public string Description { get; set; }
    public string CommandLine { get; set; }
    
    [XmlAttribute]
    public string TargetExtension { get; set; }

    public List<PresetParameter> ParametersToAsk { get; set; }

    public Preset()
    {
        ActivatorName = string.Empty;
        Description = string.Empty;
        CommandLine = string.Empty;
        TargetExtension = string.Empty;
        ParametersToAsk = new List<PresetParameter>();
    }
}
