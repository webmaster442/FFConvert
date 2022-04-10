namespace FFConvert.Tests;

[TestFixture]
internal class ProgramConfigurationExtensionsTests
{
    private ProgramConfiguration _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new ProgramConfiguration();
    }

    [Test]
    public void EnsureThat_TryGetFFmpeg_ReturnsTrue_ValidConfig() 
    {
        Assert.IsTrue(_sut.TryGetFFmpeg(out string _));
    }

    [Test]
    public void EnsureThat_TryGetFFProbe_ReturnsTrue_ValidConfig()
    {
        Assert.IsTrue(_sut.TryGetFFProbe(out string _));
    }
}
