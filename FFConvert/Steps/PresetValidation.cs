using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Steps
{
    internal class PresetValidation : BaseStep
    {
        private readonly IImplementationsOf<IConverter> _converters;
        private readonly IImplementationsOf<IValidator> _validators;

        public PresetValidation(IImplementationsOf<IConverter> converters,
                                IImplementationsOf<IValidator> validators)
        {
            _converters = converters;
            _validators = validators;
        }

        public override bool TryExecute(State state)
        {
            var presetToUse = state.Presets.FirstOrDefault(x => x.ActivatorName == state.Arguments.PresetName);
            if (presetToUse == null)
            {
                AddIssue(Resources.ErrorPresetNotFound, state.Arguments.PresetName);
            }
            else
            {
                state.CurrentPreset = presetToUse;
            }

            if (!state.CurrentPreset.IsValid())
            {
                AddIssue(Resources.ErrorInvalidPreset);
            }
            else
            {
                CheckConvertersNames(state.CurrentPreset);
                CheckValidatorNames(state.CurrentPreset);
            }

            return AreNoIssues();
        }

        private void CheckValidatorNames(Preset currentPreset)
        {
            var validatorNames = currentPreset.ParametersToAsk
                .Where(x => !string.IsNullOrEmpty(x.ValidatorName))
                .Select(x => x.ValidatorName!);

            foreach (var validatorName in validatorNames)
            {
                if (!_validators.Contains(validatorName))
                    AddIssue(Resources.ErrorUnknownValidator, validatorName);
            }

        }

        private void CheckConvertersNames(Preset currentPreset)
        {
            var converterNames = currentPreset.ParametersToAsk
                .Where(x => !string.IsNullOrEmpty(x.ConverterName))
                .Select(x => x.ConverterName!);

            foreach (var converterName in converterNames)
            {
                if (!_validators.Contains(converterName))
                    AddIssue(Resources.ErrorUnknownConverter, converterName);
            }
        }
    }
}
