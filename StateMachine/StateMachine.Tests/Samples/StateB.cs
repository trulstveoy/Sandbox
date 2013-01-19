using System;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateB : IState
    {
        public Event Reached15 = new Event();

        public void Execute(IData data)
        {
            if (App.Worker.Value >= 15)
            {
                Reached15.Set();
            }
        }
    }
}