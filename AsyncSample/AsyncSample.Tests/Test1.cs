namespace AsyncSample.Tests
{
    using System;
    using Xunit;

    public class Test1
    {
        [Fact]
        public async void DoTest()
        {
            var instance = new AsyncSample.Single();
            string result = await instance.Bar();

            Assert.Equal(DateTime.Now.Year, DateTime.Parse(result).Year);

        }
    }
}
