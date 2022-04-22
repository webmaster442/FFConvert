namespace FFConvert.Tests;

[TestFixture]
internal class AgumentExtensionsTests
{
    private static Arguments CreateSut(params string[] parameters) => new Arguments(parameters);

    private static Arguments CreateSut(string cmd)
    {
        if (cmd == null)
            return new Arguments(new string[] { });

        return new Arguments(cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

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

    [TestCase("", true)]
    [TestCase("help", true)]
    [TestCase(null, true)]
    [TestCase("asfd", false)]
    public void EnsureThat_Is_GenericHelpRequested_ReturnsExpected(string input, bool expected)
    {
        Arguments sut = CreateSut(input);
        var result = sut.IsGenericHelpRequested();
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void EnsureThat_Is_IsSpecificHelpRequested_ReturnsExpected()
    {
        Arguments sut = CreateSut("help", "foo");
        var result = sut.IsSpecificHelpRequested();
        Assert.IsTrue(result);
    }

    [TestCase("file preset output --foo", "--foo", true)]
    [TestCase("file preset output --bar", "--foo", false)]
    [TestCase("file preset output", "--foo", false)]
    public void EnsureThat_IsSwitchPresent_ReturnsExpected(string input, string @switch, bool expected)
    {
        Arguments sut = CreateSut(input);
        var result = sut.IsSwitchPresent(@switch);
        Assert.AreEqual(expected, result);
    }

    [TestCase("file preset output --foo bar", "--foo", "bar", true)]
    [TestCase("file preset output --foo --bar", "--foo", "", false)]
    [TestCase("file preset output", "--foo", "", false)]
    public void EnsureThat_TryGetSwitchWithValue_ReturnsExpected(string input, string @switch, string expectedValue, bool expected)
    {
        Arguments sut = CreateSut(input);
        var result = sut.TryGetSwitchWithValue(@switch, out var value);
        Assert.AreEqual(expectedValue, value);
        Assert.AreEqual(expected, result);
    }

}
