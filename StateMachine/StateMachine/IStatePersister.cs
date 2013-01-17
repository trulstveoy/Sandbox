using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface IStatePersister
    {
        List<IState> Get(Guid id);
        void Set(Guid id, List<IState> states);
    }
}