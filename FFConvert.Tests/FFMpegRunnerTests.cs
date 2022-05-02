namespace FFConvert.Tests;

[TestFixture]
internal class FFMpegRunnerTests
{
    private FFMpegRunner _sut;
    private List<FFMpegOutput> _outputs;
    
    [TearDown]
    public void Teardown()
    {
        _sut.ProgressReporter -= OnreportProgress;
        _sut = null;
    }

    [SetUp]
    public void Setup()
    {
        _sut = new FFMpegRunner(new ProgramConfiguration());
        _sut.ProgressReporter += OnreportProgress;
        _outputs = new List<FFMpegOutput>();
    }

    private void OnreportProgress(object sender, FFMpegOutput e)
    {
        _outputs.Add(e);
    }

    [Test, Timeout(5000)]
    public void EnsureThat_Probe_ParsesXml()
    {
        var task = _sut.Probe(new FFMpegCommand(), CancellationToken.None);
        task.Wait();
        var result = task.Result;

        Assert.IsNotNull(result);
        Assert.AreEqual("test.wav", result.Format.Filename);
        Assert.IsTrue(result.Format.Duration.HasValue);
        Assert.AreEqual(200.0, result.Format.Duration.Value, 1E-6);
    }

    [Test, Timeout(5000)]
    public void EnsureThat_Run_ReportsCorrectly()
    {
        _outputs.Clear();
        var task = _sut.Run(new FFMpegCommand(), CancellationToken.None);
        task.Wait();

        Assert.AreEqual(TimeSpan.FromSeconds(50), _outputs[0].Time);
        Assert.AreEqual(TimeSpan.FromSeconds(100), _outputs[1].Time);
        Assert.AreEqual(TimeSpan.FromSeconds(150), _outputs[2].Time);
        Assert.AreEqual(TimeSpan.FromSeconds(200), _outputs[3].Time);
        Assert.AreEqual(5, _outputs.Count);
    }
}
