namespace FFConvert.Tests
{
    internal sealed class TestStep : IStep, IDisposable
    {
        public bool DisposeCalled { get; private set; }

        public TestStep(bool returnValue, params string[] issues)
        {
            _returnValue = returnValue;
            Issues = issues;
        }

        private bool _returnValue;

        public IEnumerable<string> Issues { get; }

        public void Dispose()
        {
            if (DisposeCalled)
                throw new ObjectDisposedException(nameof(TestStep));

            DisposeCalled = true;
        }

        public bool TryExecute(State state)
        {
            return _returnValue;
        }
    }

    [TestFixture]
    internal class StepRunnerTests
    {
        private Mock<IConsole> _consoleMock;

        [SetUp]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
            _consoleMock.Setup(x => x.Error(It.IsAny<string[]>()));
        }

        [Test]
        public void EnsureThat_Using_End_CallsDisposeOnSteps()
        {
            var disposableStep = new TestStep(true, Array.Empty<string>());

            using (var stepRunner = new StepRunner(_consoleMock.Object, disposableStep))
            {
                //empty block;
            }
            Assert.IsTrue(disposableStep.DisposeCalled);

        }

        [Test]
        public void EnsureThat_Run_Breaks_IfReturnWasFalse()
        {
            using var stepRunner = new StepRunner(_consoleMock.Object, new TestStep(false, "test"));
            stepRunner.Run(new State(Array.Empty<Preset>(), new ProgramConfiguration(), new Arguments(Array.Empty<string>())));

            _consoleMock.Verify(x => x.Error(It.IsAny<string[]>()), Times.Once);
        }

        [Test]
        public void EnsureThat_Run_DoesntprintIssueIfOk()
        {
            using var stepRunner = new StepRunner(_consoleMock.Object, new TestStep(true, "test"));
            stepRunner.Run(new State(Array.Empty<Preset>(), new ProgramConfiguration(), new Arguments(Array.Empty<string>())));

            _consoleMock.Verify(x => x.Error(It.IsAny<string[]>()), Times.Never);
        }

    }
}
