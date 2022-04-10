namespace FFConvert.Tests;

[TestFixture]
internal class ImplementationsOfTests
{
    private ImplementationsOf<IConverter> _converters;
    private ImplementationsOf<IValidator> _validators;

    [SetUp]
    public void Setup()
    {
        _converters = new ImplementationsOf<IConverter>();
        _validators = new ImplementationsOf<IValidator>();
    }

    [Test]
    public void EnsureThat_ImplementationsOf_Converters_GreaterThan0()
    {
        Assert.IsTrue(_converters.Count > 0);
    }

    [Test]
    public void EnsureThat_ImplementationsOf_Validators_GreaterThan0()
    {
        Assert.IsTrue(_validators.Count > 0);
    }

    [Test]
    public void EnsureThat_ImplementationsOf_Validators_KnowsListValidator()
    {
        Assert.IsTrue(_validators.Contains(nameof(ListValidator)));
    }

    [Test]
    public void EnsureThat_ImplementationsOf_Validators_GetListValidator()
    {
        var instance = _validators.Get("ListValidator");
        Assert.IsNotNull(instance);
        Assert.AreEqual(nameof(ListValidator), instance.GetType().Name);
    }

    [Test]
    public void EnsureThat_ImplementationsOf_Converters_KnowsKbpsConverter()
    {
        Assert.IsTrue(_converters.Contains(nameof(KbpsConverter)));
    }
}
