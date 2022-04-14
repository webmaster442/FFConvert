namespace FFConvert.Tests.Steps;

[TestFixture]
internal class EncodeTests : StepTestBase<Encode>
{
    private Mock<IConsole> _consoleMock;
    private Mock<IProgressReport> _progressReportMock;
    private Mock<IFFMpegRunner> _ffmpegRunnerMock;

    public override Encode CreateSut()
    {
        _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
        _progressReportMock = new Mock<IProgressReport>(MockBehavior.Strict);
        _ffmpegRunnerMock = new Mock<IFFMpegRunner>(MockBehavior.Strict);

        _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()));
        _consoleMock.Setup(x => x.Error(It.IsAny<string[]>()));

        _progressReportMock.Setup(x => x.Hide());
        _progressReportMock.Setup(x => x.Show());
        _progressReportMock.Setup(x => x.Report(It.IsAny<ConvertProgress>()));

        _ffmpegRunnerMock.Setup(x => x.Probe(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new FFProbeResult()));
        _ffmpegRunnerMock.Setup(x => x.Run(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>())).Returns(Task.Delay(1));

        return new Encode(_ffmpegRunnerMock.Object, _consoleMock.Object, _progressReportMock.Object);
    }

    [Test]
    public void EnsureThat_Run_Skips_ExistingFile()
    {
        State state = CreateState("in", "");
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "test.mp3",
            OutputFile = "FFConvert.Tests.dll",
            CommandLine = "testcmd",
        });

        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();
        _ffmpegRunnerMock.Verify(x => x.Probe(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        _ffmpegRunnerMock.Verify(x => x.Run(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public void EnsureThat_Run_ReturnsTrue_whenEverything_Ok()
    {
        State state = CreateState("in", "");
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "test.mp3",
            OutputFile = "out.mp4",
            CommandLine = "testcmd",
        });

        bool result = Sut.TryExecute(state);

        Assert.IsTrue(result);
        AssertHasNoIssues();
        _ffmpegRunnerMock.Verify(x => x.Probe(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        _ffmpegRunnerMock.Verify(x => x.Run(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void EnsureThat_Run_PrintsIssueOnException()
    {
        State state = CreateState("in", "");
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "test.mp3",
            OutputFile = "out.mp4",
            CommandLine = "testcmd",
        });

        _ffmpegRunnerMock.Setup(x => x.Run(It.IsAny<FFMpegCommand>(), It.IsAny<CancellationToken>())).Returns((Task)null);

        bool result = Sut.TryExecute(state);

        Assert.IsFalse(result);
        _consoleMock.Verify(x => x.Error(It.IsAny<string[]>()), Times.Once);
    }

    [Test]
    public void EnsureThat_Run_WhenCanceled_ReturnsFalse()
    {
        State state = CreateState("in", "");
        state.CreatedCommandLines.Add(new FFMpegCommand
        {
            InputFile = "test.mp3",
            OutputFile = "out.mp4",
            CommandLine = "testcmd",
        });

        _consoleMock.Raise(x => x.CancelEvent += null, new EventArgs());
        bool result = Sut.TryExecute(state);

        Assert.False(result);
        AssertHasIssues();
    }
}
