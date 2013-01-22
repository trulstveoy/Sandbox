using System;
using System.Collections.Generic;
using StateMachine;

namespace Runner.Fakes
{
    public class StatePersister : IStatePersister
    {
        private readonly Dictionary<Guid, List<IState>> _states = new Dictionary<Guid, List<IState>>();

        public List<IState> Get(Guid id)
        {
            List<IState> states;
            return _states.TryGetValue(id, out states) ? states : null;
        }

        public void Set(Guid id, List<IState> states)
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