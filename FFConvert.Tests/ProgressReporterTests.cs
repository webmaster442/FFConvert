namespace FFConvert.Tests;

[TestFixture]
internal class ProgressReporterTests
{
    private ProgressReporter _sut;
    private Mock<IConsole> _consoleMock;
    private List<string> _lines;
    private string _currentLine;

    [SetUp]
    public void Setup()
    {
        _lines = new List<string>();
        _currentLine = "";
        _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
        _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>())).Callback<string>(x => _lines.Add(x));
        _consoleMock.Setup(x => x.Clear()).Callback(() => _lines.Clear());
        _consoleMock.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(x =>
        {
            _currentLine += x;
            if (_currentLine.EndsWith("\n") || _currentLine.Length > 79)
            {
                _lines.Add(_currentLine);
                _currentLine = "";
            }
        });
        _consoleMock.SetupGet(x => x.WindowWidth).Returns(80);
        _consoleMock.Setup(x => x.WindowHeight).Returns(25);
        _consoleMock.Setup(x => x.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>()));
        _sut = new ProgressReporter(_consoleMock.Object);
    }

    [Test]
    public void EnsureThat_Report_DoesnotThrow()
    {
        var progress = new ConvertProgress(100, "foo", new FFMpegOutput
        {
            Bitrate = 192,
            FileSize = 120,
            Speed = 10,
            Time = TimeSpan.FromSeconds(10)
        });

        _sut.Report(progress);

        Assert.AreEqual("   │███████                                                                 │   ", _lines[0]);
        Assert.AreEqual("   │███████                                                                 │   ", _lines[1]);
        Assert.AreEqual("  foo", _lines[2]);
        Assert.AreEqual("  Speed: 10x, Remaining time: 00:00:09", _lines[3]);
    }

    [Test]
    public void EnsureThat_Show_SwitchesBuffer()
    {
        _sut.Show();
        Assert.AreEqual("\x1b[?1049h", _currentLine);
    }

    [Test]
    public void EnsureThat_Hide_SwitchesBuffer()
    {
        _sut.Hide();
        Assert.AreEqual("\x1b[?1049l", _currentLine);
    }
}
