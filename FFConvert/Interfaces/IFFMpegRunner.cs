using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IFFMpegRunner
{
    event EventHandler<FFMpegOutput>? ProgressReporter;
    Task<FFProbeResult> Probe(FFMpegCommand command, CancellationToken cancellationToken);
    Task Run(FFMpegCommand command, CancellationToken cancellationToken);
}
