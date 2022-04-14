// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Properties;
using System.Text;

namespace FFConvert.Infrastructure;

internal sealed class HelpGenerator
{
    private readonly Preset[] _presets;

    public HelpGenerator(Preset[] availablePresets)
    {
        _presets = availablePresets;
    }

    public string GetGenericHelp()
    {
        StringBuilder buffer = new();
        string presetNames = string.Join(' ', _presets.Select(x => x.ActivatorName));
        buffer.AppendFormat(Resources.GenericHelp, presetNames);
        return buffer.ToString();
    }


    public string GetHelp(string presetName)
    {
        StringBuilder buffer = new StringBuilder();
        var preset = _presets.FirstOrDefault(x => x.ActivatorName == presetName);
        if (preset == null)
        {
            buffer.AppendFormat(Resources.ErrorPresetNotFound, presetName);
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.Append(GetGenericHelp());
            return buffer.ToString();
        }

        buffer.AppendFormat(Resources.PresetHelpHeader,
                            preset.ActivatorName,
                            preset.TargetExtension,
                            preset.Description);

        if (preset.ParametersToAsk.Count > 0)
        {
            buffer.AppendLine();
            buffer.AppendLine();
            buffer.AppendLine(Resources.PresetHelpParameters);
            buffer.AppendLine();
            foreach (var parameter in preset.ParametersToAsk)
            {
                buffer.AppendFormat(Resources.PresetHelpParameterTemplate,
                                    parameter.ParameterName,
                                    parameter.ParameterDescription,
                                    parameter.IsOptional);
                buffer.AppendLine();
            }
        }

        return buffer.ToString();
    }
}
