namespace FFConvert.Tests.ValidatorConverter;

[TestFixture]
internal class KbpsConverterTests
{
    private KbpsConverter _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new KbpsConverter();
    }

    [TestCase("12", "12k")]
    [TestCase("12k", "12k")]
    public void EnsureThat_Convert_Works(string input, string expected)
    {
        string result = _sut.Convert(input);

        Assert.AreEqual(expected, result);
    }
}
