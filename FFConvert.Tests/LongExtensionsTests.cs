namespace FFConvert.Tests;

internal class LongExtensionsTests
{
    [TestCase(128L, "128 bytes")]
    [TestCase(1025L, "1.00 KiB")]
    [TestCase(1048576L, "1.00 MiB")]
    [TestCase(1074790400L, "1.00 GiB")]
    [TestCase(1100585369600L, "1.00 TiB")]
    public void EnsureThat_ToFileSize_ReturnsCorrect(long input, string expected)
    {
        string result = input.ToFileSize();
        Assert.AreEqual(expected, result);
    }
}
