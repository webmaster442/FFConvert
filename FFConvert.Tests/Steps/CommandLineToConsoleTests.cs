namespace FFConvert.Tests.Steps;

internal class CommandLineToConsoleTests : StepTestBase<CommandLineToConsole>
{
    private Mock<IConsole> _consoleMock;
    private List<string> _lines;

    public override CommandLineToConsole CreateSut()
    {
        _lines = new List<string>();
        _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
        _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>())).Callback((string line) => _lines.Add(line));
        return new CommandLineToConsole(_consoleMock.Object);
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
    public void EnsureThat_TryExecute_AddsHeader_IfSh()
    {
        State state = CreateState(new Arguments(new string[] { "file", "preset", "out", "--sh" }));

        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();

        Assert.AreEqual("#!/bin/bash", _lines[0]);
    }

    [Test]
    public void nsureThat_TryExecute_WritesCmd_ToOutput()
    {
        State state = CreateState(new Arguments(new string[] { "file", "preset", "out", "--sh" }));
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "in",
            OutputFile = "out",
            CommandLine = "test1"
        });

        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();

        Assert.AreEqual(2, _lines.Count);
        Assert.IsTrue(_lines[1].Contains("ffmpeg"));
        Assert.IsTrue(_lines[1].Contains("test1"));
    }
}
