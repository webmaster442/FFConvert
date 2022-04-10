namespace FFConvert.Tests.Steps;

[TestFixture]
internal class CheckFFmpegInstallationTests : StepTestBase<CheckFFmpegInstallation>
{
    public override CheckFFmpegInstallation CreateSut()
    {
        return new CheckFFmpegInstallation();
    }

    [Test]
    public void EnsureThat_ValidConfig_ResultsTrue()
    {
        var state = CreateState("");
        
        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();
    }


    [Test]
    public void EnsureThat_InValidConfig_ResultsFalse()
    {
        var state = CreateState("");
        state.Configuration.FFMpegDir = "/qagqg/gq";

        bool result = Sut.TryExecute(state);

        Assert.False(result);
        AssertHasIssues();
    }
}
