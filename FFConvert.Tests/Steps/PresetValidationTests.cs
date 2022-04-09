using FFConvert.Domain;
using FFConvert.Interfaces;
using FFConvert.Steps;
using Moq;
using NUnit.Framework;

namespace FFConvert.Tests.Steps;

[TestFixture]
internal class PresetValidationTests : StepTestBase<PresetValidation>
{
    private Mock<IImplementationsOf<IValidator>> _validatorsMock;
    private Mock<IImplementationsOf<IConverter>> _convertersMock;

    public override PresetValidation CreateSut()
    {
        _convertersMock = new Mock<IImplementationsOf<IConverter>>(MockBehavior.Strict);
        _validatorsMock = new Mock<IImplementationsOf<IValidator>>(MockBehavior.Strict);
        _convertersMock.Setup(x => x.Contains(It.IsAny<string>())).Returns(false);
        _validatorsMock.Setup(x => x.Contains(It.IsAny<string>())).Returns(false);
        return new PresetValidation(_convertersMock.Object, _validatorsMock.Object);
    }

    [Test]
    public void EnsureThat_NotFoundPreset_ResultsFalse()
    {
        var state = CreateState("", "foo");
        var result = Sut.TryExecute(state);

        AssertHasIssues();
        Assert.IsFalse(result);
    }

    [Test]
    public void EnsureThat_ValidPreset_NoConvNoValidator_ResultsTrue()
    {
        var state = CreateState("");
        var result = Sut.TryExecute(state);

        AssertHasNoIssues();
        Assert.IsTrue(result);
    }

    [Test]
    public void EnsureThat_InValidPreset_NoCommandLine_ResultsFalse()
    {
        var state = CreateState("");
        state.Presets[0].CommandLine = string.Empty;
        var result = Sut.TryExecute(state);

        AssertHasIssues();
        Assert.IsFalse(result);
    }


    [Test]
    public void EnsureThat_InValidPreset_InvalidParameter_ResultsFalse()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "",
            ParameterName = ""
        });
        var result = Sut.TryExecute(state);

        AssertHasIssues();
        Assert.IsFalse(result);
    }

    [Test]
    public void EnsureThat_InValidPreset_InvalidValidator_ResultsFalse()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "desc",
            ParameterName = "name",
            ValidatorName = "fooValidator",
        });
        var result = Sut.TryExecute(state);

        AssertHasIssues();
        Assert.IsFalse(result);
    }

    [Test]
    public void EnsureThat_InValidPreset_InvalidConverter_ResultsFalse()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "desc",
            ParameterName = "name",
            ConverterName = "fooConv",
        });
        var result = Sut.TryExecute(state);

        AssertHasIssues();
        Assert.IsFalse(result);
    }
}
