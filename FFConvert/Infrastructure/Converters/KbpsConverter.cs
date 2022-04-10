using FFConvert.Interfaces;

namespace FFConvert.Infrastructure.Converters;

internal class KbpsConverter : IConverter
{
    public (bool result, string converted, string issue) Convert(string input)
    {
        if (!input.EndsWith("k"))
        {
            return (true, $"{input}k", string.Empty);
        }
        return (true, input, string.Empty);
    }

}
