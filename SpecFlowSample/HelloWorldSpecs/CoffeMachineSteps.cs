using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace HelloWorldSpecs
{
    using HelloWorld;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Binding]
    public class CoffeMachineSteps
    {
        private CoffeeMachine _coffeeMachine;

        [Given(@"I have turned on the coffe machine")]
        public void GivenIHaveTurnedOnTheCoffeMachine()
        {
            _coffeeMachine = new CoffeeMachine();
        }

 
        [Given(@"I have added beans")]
        public void GivenIHaveAddedBeans()
        {
            _coffeeMachine.AddBeans();
        }

        [Given(@"I have added water")]
        public void GivenIHaveAddedWater()
        {
            _coffeeMachine.AddWater();
        }

        [When(@"I press brew")]
        public void WhenIPressBrew()
        {
            _coffeeMachine.BrewCoffee();
        }

        [Then(@"the machine should brew (.*) cup of coffee")]
        public void ThenTheMachineShouldBrewCupOfCoffee(int cups)
        {
            Coffee coffee = _coffeeMachine.GetCoffee();
            Assert.AreEqual(cups, coffee.Cups);
        }
    }
}
