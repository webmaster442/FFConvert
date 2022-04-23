// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Globalization;

using FFConvert.Interfaces;

namespace FFConvert.Infrastructure.Converters;

internal abstract class TimeConverter : IConverter
{
    private readonly string _defaultValue;

    protected TimeConverter(string defaultValue)
    {
        _defaultValue = defaultValue;
    }

    private static int Convert(string[] array, int index)
    {
        return int.Parse(array[index]);
    }

    public string Convert(string input)
    {
        if (string.IsNullOrEmpty(input))
            return _defaultValue;

        TimeSpan parsed;
        string[] parts = input.Split(':');
        switch (parts.Length)
        {
            case 1:
                parsed = TimeSpan.FromSeconds(Convert(parts, 0));
                break;
            case 2:
                int minutes = Convert(parts, 0);
                int seconds = Convert(parts, 1);
                parsed = TimeSpan.FromSeconds((minutes * 60) + seconds);
                break;
            default:
                parsed = TimeSpan.Parse(input);
                break;
        }

        return parsed.TotalSeconds.ToString(CultureInfo.InvariantCulture);
    }
}


internal class StartTimeConverter : TimeConverter
{
    public StartTimeConverter() : base("0")
    {
    }
}

internal class EndTimeConverter : TimeConverter
{
    public EndTimeConverter() : base("")
    {
    }
}