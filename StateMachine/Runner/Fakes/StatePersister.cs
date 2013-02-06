using System;
using System.Collections.Generic;
using StateMachine;

namespace Runner.Fakes
{
    public class StatePersister : IStatePersister
    {
        private readonly Dictionary<Guid, List<State>> _states = new Dictionary<Guid, List<State>>();

        public List<State> Get(Guid id)
        {
            List<State> states;
            return _states.TryGetValue(id, out states) ? states : null;
        }

        public void Set(Guid id, List<State> states)
        {
            if (_states.ContainsKey(id))
            {
                _states[id] = states;
            }
            else
            {
                _states.Add(id, states);
            }
        }
    }
}