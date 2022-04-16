namespace FFConvert.Tests.Steps;

[TestFixture]
internal class GetPresetArgumentsTests : StepTestBase<GetPresetArguments>
{
    private Mock<IConsole> _consoleMock;

    public override GetPresetArguments CreateSut()
    {
        _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
        _consoleMock.Setup(x => x.Write(It.IsAny<string>()));
        _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()));
        _consoleMock.Setup(x => x.Error(It.IsAny<string[]>()));

        return new GetPresetArguments(new ImplementationsOf<IConverter>(),
                                      new ImplementationsOf<IValidator>(),
                                      _consoleMock.Object);

    }

    [Test]
    public void EnsureThat_PresetHasNoParams_ReturnsTrue()
    {
        var state = CreateState("");
        state.CurrentPreset = state.Presets[0];
        var result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();
    }


    [Test, Timeout(1000)]
    public void EnsureThat_SimpleParamInput_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam"
        });
        state.CurrentPreset = state.Presets[0];
        _consoleMock.Setup(x => x.ReadLine()).Returns("foo");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Once);

        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_SimpleParamInput_WithConveter_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            ConverterName = nameof(KbpsConverter)
        });
        state.CurrentPreset = state.Presets[0];
        _consoleMock.Setup(x => x.ReadLine()).Returns("foo");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Once);
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }


    [Test, Timeout(1000)]
    public void EnsureThat_SimpleParamInput_OptionalParam_EmptyInput_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            IsOptional = true,
        });
        state.CurrentPreset = state.Presets[0];
        _consoleMock.Setup(x => x.ReadLine()).Returns("");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Once);
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_SimpleParamInput_OptionalParam_WithValidator_EmptyInput_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            IsOptional = true,
            ValidatorName = nameof(IntValidator)
        });
        state.CurrentPreset = state.Presets[0];
        _consoleMock.Setup(x => x.ReadLine()).Returns("");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Once);
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_SimpleParamInput__WithIncorrectCorrectInput_AsksInputAgain()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam"
        });
        state.CurrentPreset = state.Presets[0];
        _consoleMock.SetupSequence(x => x.ReadLine()).Returns("").Returns("foo");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Exactly(2));
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_BadPresetParams_ReturnsFalse()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            ValidatorName = nameof(IntValidator),
            ValidatorParameters = "min=2max=8"
        });
        state.CurrentPreset = state.Presets[0];


        _consoleMock.Setup(x => x.ReadLine()).Returns("7");

        var result = Sut.TryExecute(state);

        Assert.IsFalse(result);
        AssertHasIssues();
    }


    [Test, Timeout(1000)]
    public void EnsureThat_ValidatedInput_WithCorrectInput_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            ValidatorName = nameof(IntValidator),
            ValidatorParameters = "min=2;max=8"
        });
        state.CurrentPreset = state.Presets[0];


        _consoleMock.Setup(x => x.ReadLine()).Returns("7");

        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Once);
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_ValidatedInput_WithIncorrectCorrectInput_AsksInputAgain()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            ValidatorName = nameof(IntValidator),
            ValidatorParameters = "min=2;max=8"
        });
        state.CurrentPreset = state.Presets[0];


        _consoleMock.SetupSequence(x => x.ReadLine()).Returns("").Returns("-1").Returns("8");
        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.Error(It.IsAny<string[]>()), Times.Once);
        _consoleMock.Verify(x => x.ReadLine(), Times.Exactly(3));
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }

    [Test, Timeout(1000)]
    public void EnsureThat_ValidatedInput_OptionalParam_EmptyInput_ReturnsTrue()
    {
        var state = CreateState("");
        state.Presets[0].ParametersToAsk.Add(new PresetParameter
        {
            ParameterDescription = "test",
            ParameterName = "testparam",
            ValidatorName = nameof(IntValidator),
            ValidatorParameters = "min=2;max=8",
            IsOptional = true
        });
        state.CurrentPreset = state.Presets[0];


        _consoleMock.Setup(x => x.ReadLine()).Returns("");
        var result = Sut.TryExecute(state);

        _consoleMock.Verify(x => x.ReadLine(), Times.Exactly(1));
        Assert.IsTrue(result);
        AssertHasNoIssues();
    }
}
