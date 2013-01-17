using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface IStateFactory
    {
        IState GetState(Type type);
        List<IState> GetStates();
    }
}