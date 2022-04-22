using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFConvert.DomainServices
{
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
                > TiB => $"{size / (double)TiB:0.00} TiB",
                > GiB => $"{size / (double)GiB:0.00} GiB",
                > MiB => $"{size / (double)MiB:0.00} MiB",
                > 1024 => $"{size / (double)KiB:0.00} KiB",
                _ => $"{size} bytes",
            };
        }
    }
}
