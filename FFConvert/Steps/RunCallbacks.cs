// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class RunCallbacks : BaseStep
{
    private readonly ICallbackProvider _callbackProvider;

    public RunCallbacks(ICallbackProvider callbackProvider)
    {
        _callbackProvider = callbackProvider;
    }

    public override bool TryExecute(State state)
    {
        if (string.IsNullOrEmpty(state.CurrentPreset.ParametersCallbackName))
            return true;

        if (!_callbackProvider.Exists(state.CurrentPreset.ParametersCallbackName))
        {
            AddIssue(Resources.ErrorCallbackDoesntExist, state.CurrentPreset.ParametersCallbackName);
            return false;
        }

        _callbackProvider.Run(state.CurrentPreset.ParametersCallbackName, state.CurrentPreset.ParametersToAsk);

        return AreNoIssues();
    }
}
