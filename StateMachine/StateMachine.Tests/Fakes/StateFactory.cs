using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Processing;
using StateMachine.Tests.Samples;

namespace StateMachine.Tests.Fakes
{
    public class StateFactory : IStateFactory
    {
        private readonly Dictionary<Type, State> _states = new Dictionary<Type, State>();

        public StateFactory()
        {
            _states.Add(typeof(StateA), new StateA());
            _states.Add(typeof(StateB), new StateB());
            _states.Add(typeof(StateC), new StateC());
            _states.Add(typeof(StateD), new StateD());
        }

        public State GetState(Type type)
        {
            return _states[type];
        }

        public List<State> GetStates()
        {
            return _states.Values.ToList();
        }
    }
}