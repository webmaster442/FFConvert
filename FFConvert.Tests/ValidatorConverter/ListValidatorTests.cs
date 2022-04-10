using FFConvert.Infrastructure.Validators;
using NUnit.Framework;

namespace FFConvert.Tests.ValidatorConverter
{
    [TestFixture]
    internal class ListValidatorTests
    {
        private ListValidator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ListValidator();
        }

        [TestCase("5")]
        [TestCase("10")]
        [TestCase("15")]
        public void EnsureThat_Validate_ReturnsTrue_ValidRange(string input)
        {
            var @params = new Dictionary<string, string>
            {
                { "valid", "5,10,15" }
            };

            var result = _sut.Validate(input, @params);

            Assert.IsTrue(result.status);
            Assert.IsEmpty(result.errorMessage);
        }


        [TestCase("5k")]
        [TestCase("10k")]
        [TestCase("15k")]
        public void EnsureThat_Validate_ReturnsTrue_ValidRangeSuffix(string input)
        {
            var @params = new Dictionary<string, string>
            {
                { "valid", "5,10,15" },
                { "ignoreSuffix", "k" }
            };

            var result = _sut.Validate(input, @params);

            Assert.IsTrue(result.status);
            Assert.IsEmpty(result.errorMessage);
        }


        [TestCase("-5")]
        [TestCase("11")]
        [TestCase("16")]
        public void EnsureThat_Validate_ReturnsFalse_InvalidRange(string input)
        {
            var @params = new Dictionary<string, string>
            {
                { "valid", "5,10,15" },
                { "ignoreSuffix", "k" }
            };

            var result = _sut.Validate(input, @params);

            Assert.IsFalse(result.status);
            Assert.IsNotEmpty(result.errorMessage);
        }

        [TestCase("asdf")]
        [TestCase("11.0")]
        [TestCase("11,0")]
        public void EnsureThat_Validate_ReturnsFalse_ParseIssue(string input)
        {
            var @params = new Dictionary<string, string>
            {
                { "valid", "5,10,15" },
                { "ignoreSuffix", "k" }
            };

            var result = _sut.Validate(input, @params);

            Assert.IsFalse(result.status);
            Assert.IsNotEmpty(result.errorMessage);
        }
    }
}
