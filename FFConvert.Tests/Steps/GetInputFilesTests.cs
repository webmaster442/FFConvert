using FFConvert.Steps;
using NUnit.Framework;

namespace FFConvert.Tests.Steps;

[TestFixture]
internal class CollectInputFilesTests : StepTestBase<CollectInputFiles>
{
    public override CollectInputFiles CreateSut()
    {
        return new CollectInputFiles();
    }

    public override void OneSetup()
    {
        base.OneSetup();
        CreateInputFiles();
    }


    [Test]
    public void EnsureThat_NoFiles_ResultsFalse()
    {
        var state = CreateState("*.asd");
        bool result = Sut.TryExecute(state);
        Assert.AreEqual(false, result);
        AssertHasIssues();
        Assert.IsEmpty(state.InputFiles);
    }

    [Test]
    public void EnsureThat_NoFile_ResultsFalse()
    {
        var state = CreateState("foo.bar");
        bool result = Sut.TryExecute(state);
        Assert.AreEqual(false, result);
        AssertHasIssues();
        Assert.IsEmpty(state.InputFiles);
    }

    [TestCase("*.mp3")]
    [TestCase("*.mp*")]
    [TestCase("*.m?4")]
    [TestCase("*.m4?")]
    [TestCase("foo.*")]
    public void EnsureThat_WildcardFiles_ResultsTrue(string input)
    {
        var state = CreateState(input);
        var result = Sut.TryExecute(state);
        Assert.AreEqual(true, result);
        AssertHasNoIssues();
        Assert.IsNotEmpty(state.InputFiles);
    }

    [TestCase("foo.mp4")]
    [TestCase("bar.wma")]
    public void EnsureThat_SingleFile_ResultsTrue(string input)
    {
        var state = CreateState(input);
        var result = Sut.TryExecute(state);

        Assert.AreEqual(true, result);
        AssertHasNoIssues();
        Assert.IsNotEmpty(state.InputFiles);
    }
}
