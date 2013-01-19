using System;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateA : IState
    {
        public Event Reached5 = new Event();
        public Event Reaced10 = new Event();

        public void Execute(IData data)
        {
            if (App.Worker.Value >= 5)
            {
                Reached5.Set();
            }

            if (App.Worker.Value >= 10)
            {
                Reaced10.Set();
            }
        }
    }
}