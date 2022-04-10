using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class CheckFFmpegInstallation : BaseStep
{
    public override bool TryExecute(State state)
    {
        if (!state.Configuration.TryGetFFmpeg(out string _))
            AddIssue(Resources.ErrorFFmpegNotFound, state.Configuration.FFMpegDir);

        if (!state.Configuration.TryGetFFProbe(out string _))
            AddIssue(Resources.ErrorFFprobeNotFound, state.Configuration.FFMpegDir);

        return AreNoIssues();
    }
}
