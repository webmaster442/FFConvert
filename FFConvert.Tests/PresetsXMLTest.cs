namespace FFConvert.Tests;

[TestFixture, NonParallelizable, SingleThreaded]
internal class PresetsXMLTest
{
    private ImplementationsOf<IConverter> _converters;
    private ImplementationsOf<IValidator> _validators;
    private Preset[] _presets;


    [SetUp]
    public void Setup()
    {
        _converters = new();
        _validators = new();
        PresetManager manager = new PresetManager();
        manager.TryLoadPresets(out _presets);
    }

    [Test]
    [Order(0)]
    public void EnsureThat_Xml_IsLoadable()
    {
        Assert.IsNotEmpty(_presets);
    }

    [Test]
    [Order(1)]
    public void EnsureThat_Presets_AreGood()
    {
        for (int i=0; i < _presets.Length; i++)
        {
            Preset preset = _presets[i];
            AssertStaticValidation(preset, i);
            AssertValidationParamTokenization(preset, i);
            AssertValidatorNames(preset, i);
            AsssertConverterNames(preset, i);
        }
    }

    private void AssertStaticValidation(Preset preset, int i)
    {
        if (string.IsNullOrEmpty(preset.ActivatorName))
            Assert.Fail($"Missing ActivatorName at preset {i}");

        if (string.IsNullOrEmpty(preset.Description))
            Assert.Fail($"Missing Description at preset {i}");

        if (string.IsNullOrEmpty(preset.CommandLine))
            Assert.Fail($"Missing CommandLine at preset {i}");

        if (string.IsNullOrEmpty(preset.TargetExtension))
            Assert.Fail($"Missing TargetExtension at preset {i}");

        if (preset.ParametersToAsk.Count > 0)
        {
            for (int j=0; j < preset.ParametersToAsk.Count; j++)
            {
                PresetParameter parameter = preset.ParametersToAsk[j];

                if (string.IsNullOrEmpty(parameter.ParameterName))
                    Assert.Fail($"Missing ParameterName for parameter {j} in preset {i}");

                if (string.IsNullOrEmpty(parameter.ParameterDescription))
                    Assert.Fail($"Missing ParameterDescription for parameter {j} in preset {i}");

                if (!string.IsNullOrEmpty(parameter.OptionalContent) 
                    && !parameter.IsOptional)
                {
                    Assert.Fail($"OptionalContent is set, but parameter {j} is not optional in preset {i}");
                }

                if (!string.IsNullOrEmpty(parameter.ValidatorParameters)
                    && string.IsNullOrEmpty(parameter.ValidatorName))
                {
                    Assert.Fail($"ValidatorParameters is set, but ValidatorName is not specified in parameter {j}  in preset {i}");
                }

            }
        }
    }

    private void AssertValidationParamTokenization(Preset preset, int i)
    {
        if (preset.ParametersToAsk.Count > 0)
        {
            for (int j = 0; j < preset.ParametersToAsk.Count; j++)
            {
                PresetParameter parameter = preset.ParametersToAsk[j];
                bool tokenizable = parameter.TryGetValidatorParamDictionary(out _);
                if (!tokenizable)
                    Assert.Fail($"ValidatorParameters is not tokenizable for preset param {j} in preset {i}");
            }
        }
    }

    private void AsssertConverterNames(Preset preset, int i)
    {
        if (preset.ParametersToAsk.Count > 0)
        {
            for (int j = 0; j < preset.ParametersToAsk.Count; j++)
            {
                PresetParameter parameter = preset.ParametersToAsk[j];
                if (!string.IsNullOrEmpty(parameter.ConverterName)
                    && !_converters.Contains(parameter.ConverterName))
                {
                    Assert.Fail($"converter {parameter.ConverterName} doesn't exist. Parameter: {j} in preset {i}");
                }
            }
        }
    }

    private void AssertValidatorNames(Preset preset, int i)
    {
        if (preset.ParametersToAsk.Count > 0)
        {
            for (int j = 0; j < preset.ParametersToAsk.Count; j++)
            {
                PresetParameter parameter = preset.ParametersToAsk[j];
                if (!string.IsNullOrEmpty(parameter.ValidatorName)
                    && !_validators.Contains(parameter.ValidatorName))
                {
                    Assert.Fail($"validator {parameter.ValidatorName} doesn't exist. Parameter: {j} in preset {i}");
                }
            }
        }
    }
}
