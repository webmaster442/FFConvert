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

    public static bool TryGetValidatorParamDictionary(this PresetParameter parameter, out IDictionary<string, string> parameters)
    {
        try
        {
            parameters = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(parameter.ValidatorParameters))
            {
                return false;
            }

            string[] argumentPairs = parameter.ValidatorParameters.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (string argumentPair in argumentPairs)
            {
                string[] keyValue = argumentPair.Split('=', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (keyValue.Length == 2)
                {
                    parameters.Add(keyValue[0], keyValue[1]);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return true;
        }
        catch (Exception)
        {
            parameters = new Dictionary<string, string>();
            return false;
        }

    }
}
