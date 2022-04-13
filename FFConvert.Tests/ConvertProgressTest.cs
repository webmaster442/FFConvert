namespace FFConvert.Tests;

[TestFixture]
internal class ConvertProgressTest
{
    private ConvertProgress _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new ConvertProgress(100, "foo", new FFMpegOutput
        {
            Bitrate = 192,
            FileSize = 120,
            Speed = 10,
            Time = TimeSpan.FromSeconds(10)
        });
    }

    [Test]
    public void EnsureThat_Percent_IsCorrect()
    {
        Assert.AreEqual(10, _sut.Percent);
    }

    [Test]
    public void EnsureThat_StatusMsg_IsCorrect()
    {
        Assert.AreEqual("Speed: 10x, Remaining time: 00:00:09", _sut.StatusMsg);
    }


    [Test]
    public void EnsureThat_ProcessedFile_IsCorrect()
    {
        Assert.AreEqual("foo", _sut.ProcessedFile);
    }
}
