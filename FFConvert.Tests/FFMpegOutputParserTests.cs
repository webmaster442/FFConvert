namespace FFConvert.Tests;

[TestFixture]
internal class FFMpegOutputParserTests
{
    [Test]
    public void EnsureThat_Parse_Works()
    {
        string[] _testData = new[]
        {
            "bitrate=170.42kbits/s",
            "total_size=709965",
            "out_time_us=35456479",
            "out_time_ms=35456479",
            "out_time=00:00:35.456479",
            "dup_frames=0",
            "drop_frames=0",
            "speed=54.8x"
        };

        var result = FFMpegOutputParser.Parse(_testData);
        Assert.AreEqual(170.42, result.Bitrate, 1E-2);
        Assert.AreEqual(709965, result.FileSize);
        Assert.AreEqual(35.456479, result.Time.TotalSeconds, 1E-4);
        Assert.AreEqual(54.8, result.Speed, 1E-2);
    }
}
