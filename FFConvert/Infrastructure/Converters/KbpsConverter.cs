using FFConvert.Interfaces;

namespace FFConvert.Infrastructure.Converters;

internal class KbpsConverter : IConverter
{
    public string Convert(string input)
    {
        if (!input.EndsWith("k"))
        {
            return $"{input}k";
        }
        return input;
    }
}
