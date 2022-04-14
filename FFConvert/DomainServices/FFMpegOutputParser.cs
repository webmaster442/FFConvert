// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using System.Globalization;

namespace FFConvert.DomainServices;

internal static class FFMpegOutputParser
{
    private const string Bitrate = "bitrate=";
    private const string Size = "total_size=";
    private const string Time = "out_time_us=";
    private const string Speed = "speed=";

    private static bool TryGet(string line, string key, out string value)
    {
        if (line.StartsWith(key))
        {
            value = line[key.Length..];
            return true;
        }
        value = string.Empty;
        return false;
    }

    public static FFMpegOutput Parse(IEnumerable<string> packet)
    {
        FFMpegOutput result = new();
        foreach (string? line in packet)
        {
            if (TryGet(line, Bitrate, out string rate) && rate != "N/A")
                result.Bitrate = float.Parse(rate.Replace("kbits/s", ""), CultureInfo.InvariantCulture);

            if (TryGet(line, Size, out string size))
                result.FileSize = long.Parse(size, CultureInfo.InvariantCulture);

            if (TryGet(line, Time, out string time))
                result.Time = TimeSpan.FromMilliseconds(double.Parse(time, CultureInfo.InvariantCulture) / 1000);

            if (TryGet(line, Speed, out string speed) && speed != "N/A")
                result.Speed = float.Parse(speed.Replace("x", ""), CultureInfo.InvariantCulture);

        }
        return result;
    }
}
