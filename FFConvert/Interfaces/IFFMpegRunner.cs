using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IFFMpegRunner
{

    Action<FFMpegOutput>? Reporter { get; set; }
    Task<FFProbeResult> Probe(FFMpegCommand command, CancellationToken cancellationToken);
    Task Run(FFMpegCommand command, CancellationToken cancellationToken);
}
