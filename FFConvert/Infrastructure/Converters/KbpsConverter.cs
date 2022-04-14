// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

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
