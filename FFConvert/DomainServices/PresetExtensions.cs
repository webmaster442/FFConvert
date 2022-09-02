// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Reflection;

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

            if (parameter.ValidatorParameters == null)
            {
                return true;
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

    public static PresetParameter? GetParameterByName(this IEnumerable<PresetParameter> parameters, string name)
    {
        return parameters.FirstOrDefault(x => x.ParameterName == name);
    }

    public static T? ParseParameterValue<T>(this PresetParameter presetParameter)
    {
        if (string.IsNullOrEmpty(presetParameter.Value))
            return default;

        var parse = typeof(T).GetMethod("Parse", BindingFlags.Static, new Type[] { typeof(string) } );

        if (parse == null)
            return default;

        object? result = parse.Invoke(null, new object[] { presetParameter.Value });

        return (T?)result;
    }

}
