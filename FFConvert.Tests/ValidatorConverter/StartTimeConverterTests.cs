namespace FFConvert.Tests.ValidatorConverter;

[TestFixture]
internal class StartTimeConverterTests
{
    private StartTimeConverter _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new StartTimeConverter();
    }

    [TestCase("", "0")]
    [TestCase("0", "0")]
    [TestCase("61", "61")]
    [TestCase("1:00", "60")]
    [TestCase("1:59", "119")]
    [TestCase("1:00:00", "3600")]
    [TestCase("128:12", "7692")]
    public void EnsureThat_Convert_ReturnsExpected(string input, string expected)
    {
        var result = _sut.Convert(input);
        Assert.AreEqual(expected, result);
    }
}
