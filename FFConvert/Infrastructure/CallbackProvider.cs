// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

internal class CallbackProvider : ICallbackProvider
{
    private readonly Dictionary<string, Action<IReadOnlyList<PresetParameter>>> _callbackTable;

    private const string Start = "%starttime%";
    private const string End = "%endtime%";

    public CallbackProvider()
    {
        _callbackTable = new Dictionary<string, Action<IReadOnlyList<PresetParameter>>>
        {
            { "CutPresetCallback", CutPresetCallback }
        };
    }

    private void CutPresetCallback(IReadOnlyList<PresetParameter> parameters)
    {
        var startTime = parameters.GetParameterByName(Start);
        var endTime = parameters.GetParameterByName(End);

        if (startTime == null || endTime == null)
            throw new Exception("Preset error");


        if (string.IsNullOrEmpty(endTime.Value))
        {
            endTime.Value = "59:59:59";
        }

        var parsedEndTime = endTime.ParseParameterValue<TimeSpan>();
        var parsedStartTime = startTime.ParseParameterValue<TimeSpan>();

        var calculated = parsedEndTime - parsedStartTime;

        endTime.Value = $"{calculated.Hours}:{calculated.Minutes}:{calculated.Seconds}";
    }

    public bool Exists(string callbackName)
    {
        return _callbackTable.ContainsKey(callbackName);
    }

    public void Run(string callbackName, IReadOnlyList<PresetParameter> parameters)
    {
        _callbackTable[callbackName].Invoke(parameters);
    }
}
