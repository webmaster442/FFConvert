using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class PresetExtensions
{
    public static bool IsValid(this Preset preset)
    {
        bool baseValid = !string.IsNullOrEmpty(preset.ActivatorName)
            && !string.IsNullOrEmpty(preset.Description)
            && !string.IsNullOrEmpty(preset.CommandLine)
            && !string.IsNullOrEmpty(preset.TargetExtension);

        if (preset.ParametersToAsk.Count == 0)
            return baseValid;

        return baseValid
            && preset.ParametersToAsk.All(x => x.IsValid());

    }

    public static bool IsValid(this PresetParameter parameter)
    {
        bool baseValid = !string.IsNullOrEmpty(parameter.ParameterName)
            && !string.IsNullOrEmpty(parameter.ParameterDescription);

        if (!string.IsNullOrEmpty(parameter.OptionalContent))
            return baseValid && parameter.IsOptional == true;

        if (!string.IsNullOrEmpty(parameter.ValidatorParameters))
            return baseValid && !string.IsNullOrEmpty(parameter.ValidatorName);

        return baseValid;

    }
}
