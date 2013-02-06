using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface IStatePersister
    {
        List<State> Get(Guid id);
        void Set(Guid id, List<State> states);
    }
}