// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class FFProbeResultExtensions
{
    public static bool IsValid(this FFProbeResult fFProbeResult)
    {
        return fFProbeResult.Format.BitRate > 0
            && fFProbeResult.Format.Size > 0
            && fFProbeResult.Format.Duration > 0;
    }
}
