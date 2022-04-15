namespace FFConvert.Tests.ValidatorConverter;

[TestFixture]
internal class TimeValidatorTests
{
    private TimeValidator _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new TimeValidator();
    }


    [TestCase("", true)]
    [TestCase("0", true)]
    [TestCase("123", true)]
    [TestCase("11:22", true)]
    [TestCase("00:11:22", true)]
    [TestCase("asdf", false)]
    [TestCase("-1", false)]
    public void EnsureThat_Validate_Returns_Expected(string input, bool expected)
    {
        var result = _sut.Validate(input, new Dictionary<string, string>());
        Assert.AreEqual(expected, result.status);
    }
}
