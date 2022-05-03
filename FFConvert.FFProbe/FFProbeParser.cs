// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Xml.Serialization;

namespace FFConvert.FFProbe;

public static class FFProbeParser
{
    public static FfprobeType Parse(string input)
    {
        XmlSerializer serializer = new(typeof(FfprobeType), "http://www.ffmpeg.org/schema/ffprobe");
        using (var reader = new StringReader(input))
        {
            return (FfprobeType)serializer.Deserialize(reader);
        }
    }

    public static double GetDuration(FfprobeType input)
    {
        var format = input?.Format;

        if (format == null
            || !format.Duration.HasValue
            || !format.Start_time.HasValue)
        {
            return 0;
        }

        return format.Duration.Value - format.Start_time.Value;
    }
}
