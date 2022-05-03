// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class CheckIfTargetDirExists : BaseStep
{
    public override bool TryExecute(State state)
    {
        var dir = state.Arguments.OutputDirectory;

        if (!Directory.Exists(dir))
        {
            AddIssue(Resources.ErrorOutputDirNotExist, dir);
        }

        return AreNoIssues();
    }
}
