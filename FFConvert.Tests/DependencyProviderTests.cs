namespace FFConvert.Tests
{
    [TestFixture, NonParallelizable, SingleThreaded]
    internal class DependencyProviderTests
    {
        private string _configFile;

        [Test]
        [Order(0)]
        public void EnsureThat_DependencyProvider_Ctor_CreatesConfig()
        {
            _configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
            if (File.Exists(_configFile))
            {
                File.Delete(_configFile);
            }

            var sut = new DependencyProvider();
            FileAssert.Exists(_configFile);
        }

        [Test]
        [Order(1)]
        public void EnsureThat_DependencyProvider_Ctor_LoadsConfig()
        {
            _configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
            FileAssert.Exists(_configFile);
            Assert.DoesNotThrow(() =>
            {
                var sut = new DependencyProvider();
            });
        }

        [Test]
        [Order(2)]
        public void EnsureThat_DependencyProvider_Ctor_InitializesAll()
        {
            var sut = new DependencyProvider();
            Assert.IsNotNull(sut.Validators);
            Assert.IsNotNull(sut.Configuration);
            Assert.IsNotNull(sut.Converters);
            Assert.IsNotNull(sut.FFMpegRunner);
            Assert.IsNotNull(sut.Console);
            Assert.IsNotNull(sut.ProgressReporter);
        }


    }
}
