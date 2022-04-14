// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

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
