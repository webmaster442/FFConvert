using FFConvert.DomainServices;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace FFConvert.Tests;

[TestFixture]
public class FileSystemTests
{
    private string _testTempFile;

    [SetUp]
    public void Setup()
    {
        Environment.CurrentDirectory = Path.GetTempPath();
        _testTempFile = Path.Combine(Environment.CurrentDirectory, "test.mp3");
        File.WriteAllText(_testTempFile, "");
    }

    [TearDown]
    public void Teardown()
    {
        if (File.Exists(_testTempFile))
            File.Delete(_testTempFile);
    }


    [TestCase("*.mp3")]
    [TestCase("asd.mp3")]
    [TestCase("*.*")]
    [TestCase("?d.*")]
    public void EnsureThat_GetWorkingDirectoryFromInputFile_Returns_CurrentDir(string input)
    {
        string result = FileSystem.GetWorkingDirectoryFromInputFile(input);
        Assert.AreEqual(Environment.CurrentDirectory, result);
    }


    [TestCase(@"c:\*.mp3", @"c:\")]
    [TestCase(@"c:\foo\test.mp3", @"c:\foo")]
    public void EnsureThat_GetWorkingDirectoryFromInputFile_Returns_Correct(string input, string expected)
    {
        string result = FileSystem.GetWorkingDirectoryFromInputFile(input);
        Assert.AreEqual(expected, result);
    }

    [TestCase(@"\foo\bar.mp3")]
    [TestCase(@"..\foo\bar.mp3")]
    public void EnsureThat_GetWorkingDirectoryFromInputFile_Returns_RelativeGood(string input)
    {
        string expected = Path.GetDirectoryName(Path.GetFullPath(input));
        string result = FileSystem.GetWorkingDirectoryFromInputFile(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void EnsureThat_CreateOutputFile()
    {
        const string expected = @"d:\test\foo.mkv";
        string result = FileSystem.CreateOutputFile(@"c:\input\foo.mp4", ".mkv", @"d:\test");
        Assert.AreEqual(expected, result);
    }

    [TestCase("*.mp3")]
    [TestCase("tes?.mp3")]
    [TestCase("test.mp*")]
    public void EnsureThat_GetFilesMatchingWildCard_ReturnsCorrect(string inputPattern)
    {
        var results = FileSystem.GetFilesMatchingWildCard(Environment.CurrentDirectory, inputPattern).ToArray();
        Assert.AreEqual(1, results.Length);
        Assert.AreEqual(_testTempFile, results[0]);
    }

}
