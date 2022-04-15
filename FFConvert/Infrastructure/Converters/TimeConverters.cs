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

    public string Convert(string input)
    {
        if (string.IsNullOrEmpty(input))
            return _defaultValue;

        TimeSpan time = TimeSpan.Parse(input);

        return time.TotalSeconds.ToString(CultureInfo.InvariantCulture);
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