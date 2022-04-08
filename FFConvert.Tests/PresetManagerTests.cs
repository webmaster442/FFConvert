using FFConvert.Infrastructure;
using NUnit.Framework;
using System;
using System.IO;

namespace FFConvert.Tests;

[TestFixture, SingleThreaded, NonParallelizable]
public class PresetManagerTests
{
    private PresetManager _sut;
    private string _sampleFile;

    [SetUp]
    public void Setup()
    {
        _sut = new PresetManager();
        _sampleFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets.sample.xml");
        if (File.Exists(_sampleFile)) File.Delete(_sampleFile);
    }

    [Test]
    [Order(0)]
    public void EnsureThat_PresetsExitst_ReturnsTrue()
    {
        Assert.IsTrue(_sut.PresetsExits);
    }

    [Test]
    [Order(1)]
    public void EnsureThat_TryLoadPresets_ReturnsData()
    {
        bool result = _sut.TryLoadPresets(out var presets);
        Assert.IsTrue(result);
        Assert.IsNotEmpty(presets);
    }

    [Test]
    public void EnsureThat_CreateSamplePreset_CreatesFile()
    {
        bool result = _sut.CreateSamplePreset();
        Assert.IsTrue(result);
        FileAssert.Exists(_sampleFile);
    }

}
