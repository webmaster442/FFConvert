using System.Text.Json.Serialization;

namespace FFConvert.Domain;

internal class FFProbeResult
{
    [JsonPropertyName("format")]
    public FFProbeFormat Format { get; set; }

    public FFProbeResult()
    {
        Format = new();
    }
}
