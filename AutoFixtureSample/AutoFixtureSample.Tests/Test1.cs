namespace AutoFixtureSample.Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Xunit;
    using Xunit;
    using Xunit.Extensions;

    public class Test1
    {
        [Fact]
        public void FirstTest()
        {
            var fixture = new Fixture();

            Foo instance = fixture.Build<Foo>().CreateAnonymous();
        }

        [Theory, AutoData]
        public void SecondTest(Foo foo)
        {
            Assert.NotNull(foo);
            Assert.NotNull(foo.Bar);
        }

        [Theory, AutoMoqData]
        public void ThirdTest(Complex instance)
        {
            Assert.NotNull(instance);
            Assert.NotNull(instance.AbstractClass);
            Assert.NotNull(instance.Instance);
        }
    }
}
