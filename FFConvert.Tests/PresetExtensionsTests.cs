namespace FFConvert.Tests;

[TestFixture]
internal class PresetExtensionsTests
{
    private Preset Sut;
    private Preset ParameterSut;

    [SetUp]
    public void Setup()
    {
        Sut = new Preset
        {
            TargetExtension = ".mp4",
            Description = "Foo",
            ActivatorName = "Bar",
            CommandLine = "ff",
        };
        ParameterSut = new Preset
        {
            TargetExtension = ".mp4",
            Description = "Foo",
            ActivatorName = "Bar",
            CommandLine = "ff",
            ParametersToAsk = new List<PresetParameter>
            {
                new PresetParameter
                {
                    ParameterName = "fooparam",
                    ParameterDescription = "description"
                }
            }
        };
    }

    [Test]
    public void EnsureThat_IsValid_True_NoParams()
    {
        Assert.IsTrue(Sut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_NoExtension()
    {
        Sut.TargetExtension = string.Empty;
        Assert.IsFalse(Sut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_NoDescription()
    {
        Sut.Description = string.Empty;
        Assert.IsFalse(Sut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_NoActivatorName()
    {
        Sut.ActivatorName = string.Empty;
        Assert.IsFalse(Sut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_NoCommandLine()
    {
        Sut.CommandLine = string.Empty;
        Assert.IsFalse(Sut.IsValid());
    }
    
    [Test]
    public void EnsureThat_IsValid_True_Parameters()
    {
        Assert.IsTrue(Sut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_Parameter_NoName()
    {
        ParameterSut.ParametersToAsk[0].ParameterName = "";
        Assert.False(ParameterSut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_Parameter_NoDescription()
    {
        ParameterSut.ParametersToAsk[0].ParameterDescription = "";
        Assert.False(ParameterSut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_Parameter_WithOptionalContent_NotOptional()
    {
        ParameterSut.ParametersToAsk[0].OptionalContent= "foqg";
        Assert.False(ParameterSut.IsValid());
    }

    [Test]
    public void EnsureThat_IsValid_False_Parameter_WithValidatorParam_NoValidator()
    {
        ParameterSut.ParametersToAsk[0].ValidatorParameters = "foqg";
        Assert.False(ParameterSut.IsValid());
    }

    [TestCase("key=value")]
    [TestCase(null)]
    public void EnsureThat_TryGetValidatorParamDictionary_WorksSimple(string input)
    {
        PresetParameter sut = new PresetParameter
        {
            ValidatorParameters = input
        };

        bool result = sut.TryGetValidatorParamDictionary(out IDictionary<string, string> results);

        Assert.IsTrue(result);

    }

    [TestCase("key=value;key2=value2")]
    public void EnsureThat_TryGetValidatorParamDictionary_WoksComplex(string input)
    {
        PresetParameter sut = new PresetParameter
        {
            ValidatorParameters = input
        };

        bool result = sut.TryGetValidatorParamDictionary(out IDictionary<string, string> results);

        Assert.IsTrue(result);
        Assert.IsTrue(results.ContainsKey("key"));
        Assert.AreEqual("value", results["key"]);
        Assert.IsTrue(results.ContainsKey("key2"));
        Assert.AreEqual("value2", results["key2"]);
    }

    [TestCase("foo")]
    [TestCase("foo;")]
    [TestCase(";foo")]
    [TestCase("foo;bar")]
    [TestCase("foo=")]
    [TestCase("=bar")]
    public void EnsureThat_TryGetValidatorParamDictionary_ReturnsFalse_Invalid(string input)
    {
        PresetParameter sut = new PresetParameter
        {
            ValidatorParameters = input
        };

        bool result = sut.TryGetValidatorParamDictionary(out IDictionary<string, string> results);

        Assert.IsFalse(result);
    }
}
