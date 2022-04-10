using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Infrastructure.Validators;
using NUnit.Framework;

namespace FFConvert.Tests.ValidatorConverter;

[TestFixture]
internal class IntValidatorTests
{
    private IntValidator _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new IntValidator();
    }

    [TestCase("11", "")]
    [TestCase("11", "min=1")]
    [TestCase("11", "max=12")]
    public void EnsureThat_Validate_ReturnsTrue_ValidInput(string input, string parameters)
    {
        PresetParameter parameter = new PresetParameter
        {
            ValidatorParameters = parameters
        };

        bool parseResult = parameter.TryGetValidatorParamDictionary(out IDictionary<string, string> pars);
        Assert.IsTrue(parseResult);

        var result = _sut.Validate(input, pars);
        Assert.IsTrue(result.status);
        Assert.IsEmpty(result.errorMessage);
    }

    [TestCase("asdf", "")]
    [TestCase("11.0", "")]
    [TestCase("2147483648", "")]
    [TestCase("-2147483649", "")]
    [TestCase("11", "max=10")]
    [TestCase("11", "min=12")]
    public void EnsureThat_Validate_ReturnsFalse_InvalidInput(string input, string parameters)
    {
        PresetParameter parameter = new PresetParameter
        {
            ValidatorParameters = parameters
        };

        bool parseResult = parameter.TryGetValidatorParamDictionary(out IDictionary<string, string> pars);
        Assert.IsTrue(parseResult);

        var result = _sut.Validate(input, pars);

        Assert.False(result.status);
        Assert.IsNotEmpty(result.errorMessage);
    }
}
