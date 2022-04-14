namespace FFConvert.Tests.Steps;

internal abstract class StepTestBase<T> where T : IStep
{
    public string Directory { get; private set; }

    protected List<string> Files { get; private set; }

    protected T Sut { get; private set; }

    [OneTimeSetUp]
    public virtual void OneSetup()
    {
        Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        Directory = Environment.CurrentDirectory;
    }

    [SetUp]
    public virtual void Setup()
    {
        Sut = CreateSut();
    }

    [TearDown]
    public virtual void Teardown()
    {
        if (Sut is IDisposable disposable)
            disposable.Dispose();
    }

    public abstract T CreateSut();

    protected void CreateInputFiles()
    {
        Files = new List<string>
        {
            Path.Combine(Directory, "foo.mp4"),
            Path.Combine(Directory, "bar.wma"),
            Path.Combine(Directory, "asd.mp3"),
            Path.Combine(Directory, "abc.m4a"),
            Path.Combine(Directory, "def.m4v"),
        };
        foreach (var file in Files)
        {
            File.WriteAllText(file, "");
        }
    }

    [OneTimeTearDown]
    protected virtual void OneTearDown()
    {
        if (Files != null)
        {
            foreach (var file in Files)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
        }
    }

    protected virtual State CreateState(string input, string preset = "test")
    {
        return new State(new Preset[]
        {
            new Preset
            {
                Description = "test preset",
                ActivatorName = "test",
                CommandLine = "-i %input% -c:a copy -c:v copy %output%",
                TargetExtension = ".mkv",
            },
            new Preset
            {
                Description = "bad preset",
                ActivatorName = "bad1",
                CommandLine = "-i %input% -c:a copy -c:v copy %output% %foo%",
                TargetExtension = ".mkv",
            },
            new Preset
            {
                Description = "bad preset",
                ActivatorName = "bad2",
                CommandLine = "-i %input% -c:a copy -c:v copy %output% %foo%",
                TargetExtension = "%sourceext%",
            }
        },
        new ProgramConfiguration(),
        new Arguments(new string[] { input, preset, Directory }));
    }

    protected void AssertHasNoIssues()
    {
        Assert.IsFalse(Sut.Issues.Any());
    }

    protected void AssertHasIssues()
    {
        Assert.IsTrue(Sut.Issues.Any());
    }
}

