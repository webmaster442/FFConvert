// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Globalization;
using System.Text.Json.Serialization;

namespace FFConvert.Domain;

internal class FFProbeFormat
{
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("nb_streams")]
    public int NbStreams { get; set; }

    [JsonPropertyName("nb_programs")]
    public int NbPrograms { get; set; }

    [JsonPropertyName("format_name")]
    public string FormatName { get; set; }

    [JsonPropertyName("format_long_name")]
    public string FormatLongName { get; set; }

    [JsonPropertyName("start_time")]
    public string StartTimeStr { get; set; }

    public double StartTime => double.Parse(StartTimeStr, CultureInfo.InvariantCulture);

    [JsonPropertyName("duration")]
    public string DurationStr { get; set; }

    public double Duration => double.Parse(DurationStr, CultureInfo.InvariantCulture);

    [JsonPropertyName("size")]
    public string SizeStr { get; set; }

    public long Size => long.Parse(SizeStr, CultureInfo.InvariantCulture);

    [JsonPropertyName("bit_rate")]
    public string BitrateStr { get; set; }

    public int BitRate => int.Parse(BitrateStr, CultureInfo.InvariantCulture);

    [JsonPropertyName("probe_score")]
    public int ProbeScore { get; set; }

    [JsonPropertyName("tags")]
    public FFProbeTags Tags { get; set; }

    public FFProbeFormat()
    {
        Filename = string.Empty;
        FormatName = string.Empty;
        FormatLongName = string.Empty;
        DurationStr = "0";
        StartTimeStr = "0";
        SizeStr = "0";
        BitrateStr = "0";
        Tags = new();
    }
}
