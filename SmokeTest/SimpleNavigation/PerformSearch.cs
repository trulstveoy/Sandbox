using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAutomation.Interfaces;
using Xunit;

namespace SimpleNavigation
{
    public class PerformSearch : FluentAutomation.FluentTest
    {
        public PerformSearch()
        {
            FluentAutomation.SeleniumWebDriver.Bootstrap();
        }

        [Fact]
        public void Go()
        {
            I.Open("http://www.google.com");
            I.Enter("fluent automation").In("input");
            I.Press("{Enter}");
        }
    }
}
