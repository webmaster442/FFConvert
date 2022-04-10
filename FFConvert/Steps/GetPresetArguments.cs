using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps;

internal class GetPresetArguments : BaseStep
{
    private readonly IImplementationsOf<IConverter> _converters;
    private readonly IImplementationsOf<IValidator> _validators;
    private readonly IConsole _console;

    public GetPresetArguments(IImplementationsOf<IConverter> converters,
                              IImplementationsOf<IValidator> validators,
                              IConsole console)
    {
        _converters = converters;
        _validators = validators;
        _console = console;
    }

    public override bool TryExecute(State state)
    {
        if (!state.CurrentPreset.ParametersToAsk.Any())
            return true;

        foreach (var parameter in state.CurrentPreset.ParametersToAsk)
        {
            string input;
            if (!string.IsNullOrEmpty(parameter.ValidatorName))
            {
                input = ReadPresetValueWithValidator(parameter);
            }
            else
            { 
                input = ReadPresetValue(parameter); 
            }
            parameter.Value = ConvertValue(input, parameter);
        }

        return AreNoIssues();
    }

    private string ConvertValue(string input, PresetParameter parameter)
    {
        if (string.IsNullOrEmpty(parameter.ConverterName))
            return input;

        IConverter converter = _converters.Get(parameter.ConverterName);

        return converter.Convert(input);
    }

    private string ReadPresetValueWithValidator(PresetParameter parameter)
    {
        IDictionary<string, string> paramDictionary = new Dictionary<string, string>();

        if (parameter.ValidatorParameters != null
            && !parameter.TryGetValidatorParamDictionary(out paramDictionary))
        {
            AddIssue(Resources.ErrorPresetParamTokens);
            return string.Empty;
        }

        bool valid = false;
        string input;
        do
        {
            _console.Write(parameter.ParameterDescription);
            _console.Write(" : ");
            input = _console.ReadLine();

            if (parameter.IsOptional == false && string.IsNullOrEmpty(input))
            {
                continue;
            }

            var validator = _validators.Get(parameter.ValidatorName!);

            var (status, errorMessage) = validator.Validate(input, paramDictionary);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _console.Error(errorMessage);
            }
            valid = status;
        }
        while (!valid && !parameter.IsOptional);

        return input;

    }


    private string ReadPresetValue(PresetParameter parameter)
    {
        string input;
        do
        {
            _console.Write(parameter.ParameterDescription);
            _console.Write(" : ");
            input = _console.ReadLine();
        }
        while (string.IsNullOrEmpty(input) && !parameter.IsOptional);
        return input;
    }
}
