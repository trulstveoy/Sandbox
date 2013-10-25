using FluentAutomation;
using Xunit;

namespace SmokeTest
{
    public class WhenLoadingData : FluentTest
    {
        public WhenLoadingData()
        {
            SeleniumWebDriver.Bootstrap();
        }

        [Fact]
        public void ShouldDisplayItems()
        {
            I.Open("http://localhost:5001/");
            I.WaitUntil(() => I.Expect.Exists("a#loadData"));
            I.Click("a#loadData");
            I.Click("button#loadData");
            I.Expect.Count(10).Of("ul#items li");
        }
    }
}
