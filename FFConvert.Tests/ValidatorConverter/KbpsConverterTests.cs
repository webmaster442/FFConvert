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
        (bool result, string converted, string issue) result = _sut.Convert(input);

        Assert.IsTrue(result.result);
        Assert.AreEqual(expected, result.converted);
        Assert.IsEmpty(result.issue);
    }
}
