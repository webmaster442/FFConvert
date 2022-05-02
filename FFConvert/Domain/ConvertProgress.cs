// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Properties;

namespace FFConvert.Domain;

internal sealed class ConvertProgress
{
    public float Percent { get; }
    public string StatusMsg { get; }
    public string ProcessedFile { get; }

    public ConvertProgress(double fullTime, string file, FFMpegOutput fFMpegOutput)
    {
        Percent = (float)(fFMpegOutput.Time.TotalSeconds / fullTime) * 100.0f;
        ProcessedFile = file;
        double remain = (fullTime - fFMpegOutput.Time.TotalSeconds) / fFMpegOutput.Speed;
        string time = "Unknown";
        if (!double.IsInfinity(remain) && !double.IsNaN(remain))
        {
            time = TimeSpan.FromSeconds(remain).ToString();
        }
        StatusMsg = string.Format(Resources.StatusReportTemplate, fFMpegOutput.Speed, time);
    }

}
