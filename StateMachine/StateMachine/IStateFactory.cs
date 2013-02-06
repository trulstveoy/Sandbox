using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface IStateFactory
    {
        State GetState(Type type);
        List<State> GetStates();
    }
}