namespace FFConvert.Tests.Steps;

[TestFixture]
internal class CreateCommandLinesTests : StepTestBase<CreateCommandLines>
{
    public override CreateCommandLines CreateSut()
    {
        return new CreateCommandLines();
    }

    [Test]
    public void EnsureThat_CreateCommandLine_Noissue_ReturnsTrue()
    {
        var state = CreateState(@"test.mp4");
        state.CurrentPreset = state.Presets[0];
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        Assert.IsNotEmpty(state.CreatedCommandLines);

        string expectedCommandLine = $"-i test.mp4 -c:a copy -c:v copy {Path.Combine(Directory, "test.mkv")}";

        Assert.AreEqual(Path.Combine(Directory, "test.mkv"), state.CreatedCommandLines[0].OutputFile);
        Assert.AreEqual(expectedCommandLine, state.CreatedCommandLines[0].CommandLine);
    }

    [Test]
    public void EnsureThat_CreateCommandLine_OptionalParam_ReturnsTrue()
    {
        var state = CreateState(@"test.mp4");
        state.CurrentPreset = new Preset
        {
            TargetExtension = ".mkv",
            CommandLine = "-i %input% %output% %optional%",
            ParametersToAsk = new List<PresetParameter>
            {
                new PresetParameter
                {
                    ParameterName = "%optional%",
                    IsOptional = true,
                    OptionalContent = "--apend %optional%",
                    Value = "foo"
                }
            }
        };
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        Assert.IsNotEmpty(state.CreatedCommandLines);

        string expectedCommandLine = $"-i test.mp4 {Path.Combine(Directory, "test.mkv")} --apend foo";

        Assert.AreEqual(Path.Combine(Directory, "test.mkv"), state.CreatedCommandLines[0].OutputFile);
        Assert.AreEqual(expectedCommandLine, state.CreatedCommandLines[0].CommandLine);
    }

    [Test]
    public void EnsureThat_CreateCommandLine_OptionalParam_NoValueTrue()
    {
        var state = CreateState(@"test.mp4");
        state.CurrentPreset = new Preset
        {
            TargetExtension = ".mkv",
            CommandLine = "-i %input% %output% %optional%",
            ParametersToAsk = new List<PresetParameter>
            {
                new PresetParameter
                {
                    ParameterName = "%optional%",
                    IsOptional = true,
                    OptionalContent = "--apend %optional%",
                    Value = ""
                }
            }
        };
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        Assert.IsNotEmpty(state.CreatedCommandLines);

        string expectedCommandLine = $"-i test.mp4 {Path.Combine(Directory, "test.mkv")}";

        Assert.AreEqual(Path.Combine(Directory, "test.mkv"), state.CreatedCommandLines[0].OutputFile);
        Assert.AreEqual(expectedCommandLine, state.CreatedCommandLines[0].CommandLine);
    }


    [Test]
    public void EnsureThat_CreateCommandLine_WithSourceExt_ReturnsTrue()
    {
        var state = CreateState(@"test.mp4");
        state.CurrentPreset = state.Presets[0];
        state.CurrentPreset.TargetExtension = "%sourceext%";
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        Assert.IsNotEmpty(state.CreatedCommandLines);

        string expectedCommandLine = $"-i test.mp4 -c:a copy -c:v copy {Path.Combine(Directory, "test.mp4")}";

        Assert.AreEqual(Path.Combine(Directory, "test.mp4"), state.CreatedCommandLines[0].OutputFile);
        Assert.AreEqual(expectedCommandLine, state.CreatedCommandLines[0].CommandLine);
    }

    [Test]
    public void EnsureThat_CreateCommandLine_ParamCountMismatch_ReturnsFalse()
    {
        var state = CreateState(@"test.mp4", "bad1");
        state.CurrentPreset = state.Presets[1];
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsFalse(result);
        Assert.IsEmpty(state.CreatedCommandLines);
        AssertHasIssues();
    }


    [Test]
    public void EnsureThat_CreateCommandLine_ParamCountMismatch2_ReturnsFalse()
    {
        var state = CreateState(@"test.mp4", "bad2");
        state.CurrentPreset = state.Presets[2];
        state.InputFiles.Add(state.Arguments.FileName);
        bool result = Sut.TryExecute(state);

        Assert.IsFalse(result);
        Assert.IsEmpty(state.CreatedCommandLines);
        AssertHasIssues();
    }
}
