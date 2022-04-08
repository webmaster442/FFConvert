using System.Xml.Serialization;

namespace FFConvert.Domain;

[Serializable]
public sealed class PresetParameter
{
    [XmlAttribute]
    public string ParameterName { get; set; }

    [XmlAttribute]
    public string ParameterDescription { get; set; }

    [XmlIgnore]
    public string Value { get; set; }

    [XmlAttribute("Validator")]
    public string? ValidatorName { get; set; }

    [XmlAttribute]
    public string? ValidatorParameters { get; set; }

    [XmlAttribute("Converter")]
    public string? ConverterName { get; set; }

    [XmlAttribute]
    public bool IsOptional { get; set; }

    [XmlAttribute]
    public string? OptionalContent { get; set; }

    public PresetParameter()
    {
        IsOptional = false;
        ParameterName = string.Empty;
        ParameterDescription = string.Empty;
        Value = string.Empty;
    }
}
