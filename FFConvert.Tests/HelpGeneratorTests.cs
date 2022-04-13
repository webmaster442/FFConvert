namespace FFConvert.Tests;

[TestFixture]
internal class HelpGeneratorTests
{
    private HelpGenerator _sut;

    private string lb = Environment.NewLine;
    private string genericHelp;

    [SetUp]
    public void Setup()
    {
        genericHelp = $"FFConvert - an FfMpeg command line converter{lb}{lb}"
                    + $"  Usage: ffconvert [inputfiles] [preset] [outdir]{lb}"
                    + $"  Available presets: Test";

        _sut = new HelpGenerator(new[]
        {
            new Preset
            {
                ActivatorName = "Test",
                Description = "Test preset",
                TargetExtension = ".foo",
                ParametersToAsk = new List<PresetParameter>
                {
                    new PresetParameter
                    {
                        ParameterName = "Test parameter",
                        ParameterDescription = "Test description",
                        IsOptional = false,
                    }
                }
            }
        });
    }

    [Test]
    public void EnsureThat_GetGenericHelp_ReturnsExpected()
    {
        string result = _sut.GetGenericHelp();


        Assert.AreEqual(genericHelp, result);
    }

    [Test]
    public void EnsureThat_TryGetHelp_Prints_GenericHelp_NonExistingPreset()
    {
        string result = _sut.GetHelp("asd");

        string expected = $"Preset not found: asd{lb}{lb}"
                        + genericHelp;

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void EnsureThat_TryGetHelp_Prints_ExpectedHelp()
    {
        string result = _sut.GetHelp("Test");

        string expected = $"Preset Name:       Test{lb}"
            + $"Result extension:  .foo{lb}"
            + $"Description:       Test preset{lb}"
            + $"{lb}"
            + $"Parameters:{lb}"
            + $"{lb}"
            + $"Name:         Test parameter{lb}"
            + $"Description:  Test description{lb}"
            + $"Optional?:    False{lb}";

        Assert.AreEqual(expected, result);
    }
}
