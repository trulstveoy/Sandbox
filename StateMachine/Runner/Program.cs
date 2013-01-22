using System;
using Runner.Fakes;
using Runner.Samples;
using StateMachine;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateFactory = new StateFactory();
            var statePersister = new StatePersister();

            var machine = new Machine(stateFactory, statePersister);

            machine.Configure(p =>
                p.SetInitialState<StateA>());

            machine.Configure(p => p
                 .Setup<StateA>(x => x.Reached5)
                 .Setup<StateA>(x => x.Reaced10)
                     .TransitionTo<StateB>()
                     .TransitionTo<StateC>());

            machine.Configure(p => p
                .Setup<StateB>(x => x.Reached15)
                .Setup<StateC>(x => x.Reached20)
                    .TransitionTo<StateD>());

            machine.Initialize();

            string descriptions = machine.GetDescriptions();
            Console.WriteLine(descriptions);

            var fooData = new FooData();
            fooData.Id = Guid.NewGuid();

            for (int i = 0; i < 50; i++)
            {
                machine.Process(fooData);
                fooData.Counter++;
            }
        }
    }
}
