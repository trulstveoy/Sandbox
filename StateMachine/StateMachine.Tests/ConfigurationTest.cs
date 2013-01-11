using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine.Tests.Samples;

namespace StateMachine.Tests
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void Setup()
        {
            var machine = new Machine();
            machine.Configure(p => p
                 .Setup<StateA>(x => x.EventA)
                 .Setup<StateA>(x => x.EventB)
                     .TransitionTo<StateB>()          
                     .TransitionTo<StateC>());

            machine.Configure(p => p
                .Setup<StateB>(x => x.EventC)
                .Setup<StateC>(x => x.EventD)
                    .TransitionTo<StateD>());

            string descriptions = machine.GetDescriptions();


            var currentState = new StateA();

            machine.Run(currentState);




        }
    }
}
