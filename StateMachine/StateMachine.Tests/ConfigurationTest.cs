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
                 .Setup<StateA>(x => x.Reached5)
                 .Setup<StateA>(x => x.Reaced10)
                     .TransitionTo<StateB>()          
                     .TransitionTo<StateC>());

            machine.Configure(p => p
                .Setup<StateB>(x => x.Reached15)
                .Setup<StateC>(x => x.Reached20)
                    .TransitionTo<StateD>());

            string descriptions = machine.GetDescriptions();
            
            machine.Initialize(new State[] {new StateA(), new StateB(), new StateC(), new StateD()});

            for (int i = 0; i < 50; i++)
            {
                machine.Process();
                App.Worker.Increase();
            }
        }
    }
}
