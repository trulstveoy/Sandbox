using System;
using StateMachine.Processing;

namespace StateMachine
{
    [Serializable]
    public abstract class State 
    {
        public abstract void Execute(IData data);
    }
}
