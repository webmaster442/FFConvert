using FFConvert.Infrastructure;
using NUnit.Framework;
using System;
using System.IO;

namespace FFConvert.Tests;

[TestFixture]
internal class ProgramConsoleTests
{
    private StringWriter _output;
    private StringReader _input;
    private ProgramConsole _sut;

    [SetUp]
    public void Setup()
    {
        _input = new StringReader("line\r\n");
        _output = new StringWriter();
        Console.SetIn(_input);
        Console.SetOut(_output);
        _sut = new ProgramConsole();
    }

    [TearDown]
    public void TearDown()
    {
        _output.Dispose();
        _input.Dispose();
    }

    [Test]
    public void EnsurThat_ReadLine_ReturnsCorrect()
    {
        var result = _sut.ReadLine();
        Assert.AreEqual("line", result);
    }

    [Test]
    public void EnsureThat_WriteLine_Works()
    {
        _sut.WriteLine("test");
        Assert.AreEqual("test\r\n", _output.ToString());
    }

    [Test]
    public void EnsureThat_Write_Works()
    {
        _sut.Write("test");
        Assert.AreEqual("test", _output.ToString());
    }


    [Test]
    public void EnsureThat_Error_Works()
    {
        _sut.Error("one", "two");
        Assert.AreEqual("one\r\ntwo\r\n", _output.ToString());
    }
}
