namespace AutoFixtureSample.Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;
    using Ploeh.AutoFixture.Xunit;
    using Xunit.Extensions;

    internal class AutoMoqDataAttribute : AutoDataAttribute
    {
        internal AutoMoqDataAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }

    internal class InlineAutoMoqDataAttribute : CompositeDataAttribute
    {
        internal InlineAutoMoqDataAttribute(params object[] values)
            : base(new DataAttribute[] { 
            new InlineDataAttribute(values), new AutoMoqDataAttribute() })
        {
        }
    }
}