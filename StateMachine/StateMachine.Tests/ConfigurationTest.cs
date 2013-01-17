using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine.Tests.Fakes;
using StateMachine.Tests.Samples;

namespace StateMachine.Tests
{
    [TestClass]
    public class ConfigurationTest
    {
        private IStateFactory _stateFactory;
        private IStatePersister _persister;

        [TestInitialize]
        public void Setup()
        {
            _stateFactory = new StateFactory();
            _persister = new StatePersister();
        }

        [TestMethod]
        public void DoIt()
        {
            var machine = new Machine(_stateFactory, _persister);
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
            
            machine.Initialize();

            var fooData = new FooData();
            fooData.Id = Guid.NewGuid();

            for (int i = 0; i < 50; i++)
            {
                machine.Process(fooData);
                App.Worker.Increase();
            }
        }
    }
}
