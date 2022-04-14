// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IFFMpegRunner
{
    event EventHandler<FFMpegOutput>? ProgressReporter;
    Task<FFProbeResult> Probe(FFMpegCommand command, CancellationToken cancellationToken);
    Task Run(FFMpegCommand command, CancellationToken cancellationToken);
}
