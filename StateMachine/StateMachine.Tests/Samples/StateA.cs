using System;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateA : IState
    {
        public Action Reached5 { get; set; }
        public Action Reaced10 { get; set; }

        public void Execute(IData data)
        {
            if (App.Worker.Value >= 5)
            {
                Reached5();
            }

            if (App.Worker.Value >= 10)
            {
                Reaced10();
            }
        }
    }
}