namespace FFConvert.Tests;

[TestFixture]
internal class AgumentExtensionsTests
{
    private Arguments CreateSut(params string[] parameters) => new Arguments(parameters);

    [TestCase("in.mp3", "wav", "d:\\out", true)]
    [TestCase("in.mp3", "wav", "", false)]
    [TestCase("in.mp3", "", "d:\\out", false)]
    [TestCase("", "wav", "d:\\out", false)]
    public void EnsureThat_IsSyntaxValid_Returns_ReturnsExpected(string fileName, string preset, string outFolder, bool expected)
    {
        Arguments sut = CreateSut(fileName, preset, outFolder);
        var result = sut.IsSyntaxValid();
        Assert.AreEqual(expected, result);
    }

    [TestCase("foo.bar", false)]
    [TestCase("fo?.bar", true)]
    [TestCase("f*.bar", true)]
    [TestCase("..\\foo.bar", true)]
    public void EnsureThat_InputFileContainsWildCard_ReturnsExpected(string input, bool expected)
    {
        Arguments sut = CreateSut(input);
        var result = sut.InputFileContainsWildCard();
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void EnsureThat_Is_GenericHelpRequested_ReturnsExpected()
    {
        Arguments sut = CreateSut("help");
        var result = sut.IsGenericHelpRequested();
        Assert.IsTrue(result);
    }

    [Test]
    public void EnsureThat_Is_IsSpecificHelpRequested_ReturnsExpected()
    {
        Arguments sut = CreateSut("help", "foo");
        var result = sut.IsSpecificHelpRequested();
        Assert.IsTrue(result);
    }

}
