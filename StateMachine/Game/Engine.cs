using System;
using Game.States;
using StateMachine;

namespace Game
{
    public class Engine
    {
        private readonly IStateFactory _factory = new StateFactory();
        private readonly IStatePersister _persister = new StatePersister();
        private readonly Machine _machine; 
        private Guid _id = new Guid();

        public Engine()
        {
            _machine = new Machine(_factory, _persister);

            _machine.Configure(p =>
                p.SetInitialState<EndOfRoadState>());

            _machine.Configure(p => p
                .Setup<EndOfRoadState>(x => x.GoneNorth)
                    .TransitionTo<ForestState>());

            _machine.Configure(p => p
                .Setup<ForestState>(x => x.GoneSouth)
                    .TransitionTo<EndOfRoadState>());
        }

        public string GetFirstMessage()
        {
            var command = new Command("") {Id = _id};

            _machine.Process(command);

            return "first message";
        }

        public string ExecuteCommand(string text)
        {
            var command = new Command(text) { Id = _id };

            _machine.Process(command);

            return "some message";
        }
    }
}
