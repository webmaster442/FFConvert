namespace FFConvert.Tests.Steps;

internal class CommandLineToConsoleTests : StepTestBase<CommandLineToFile>
{
    private Mock<IConsole> _consoleMock;
    private List<string> _lines;

    public override CommandLineToFile CreateSut()
    {
        _lines = new List<string>();
        _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
        return new CommandLineToFile(_consoleMock.Object);
    }

    [TestCase("--sh", false)]
    [TestCase("--ps", false)]
    [TestCase("--bat", false)]
    [TestCase("", true)]
    [TestCase(null, true)]
    [TestCase("foo", true)]
    public void EnsureThat_CanSkip_ReturnsTrue_WhenExpected(string sw, bool expected)
    {
        State state = CreateState(new Arguments(new string[] { "file", "preset", "out", sw }));
        bool result = Sut.CanSkip(state);

    }

    [Test]
    public void EnsureThat_TryExecute_ReturnsFalse_NoFFMpeg()
    {
        State state = CreateState("");
        state.Configuration.FFMpegDir = "asdeg";

        bool result = Sut.TryExecute(state);

        Assert.IsFalse(result);
        AssertHasIssues();
    }

    [Test]
    public void nsureThat_TryExecute_WritesCmd_ToOutput()
    {
        State state = CreateState(new Arguments(new string[] { "file", "preset", "out", "--sh", "test.txt" }));
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "in",
            OutputFile = "out",
            CommandLine = "test1"
        });

        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();

        FileAssert.Exists("test.txt");
    }
}
