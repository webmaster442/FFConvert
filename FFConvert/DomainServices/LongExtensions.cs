// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Globalization;

namespace FFConvert.DomainServices;

internal static class LongExtensions
{
    private const long KiB = 1024;
    private const long MiB = KiB * 1024;
    private const long GiB = MiB * 1024;
    private const long TiB = GiB * 1024;

    public static string ToFileSize(this long size)
    {
        return size switch
        {
            >= TiB => $"{(size / (double)TiB).ToString("0.00", CultureInfo.InvariantCulture)} TiB",
            >= GiB => $"{(size / (double)GiB).ToString("0.00", CultureInfo.InvariantCulture)} GiB",
            >= MiB => $"{(size / (double)MiB).ToString("0.00", CultureInfo.InvariantCulture)} MiB",
            >= 1024 => $"{(size / (double)KiB).ToString("0.00", CultureInfo.InvariantCulture)} KiB",
            _ => $"{size} bytes",
        };
    }
}
