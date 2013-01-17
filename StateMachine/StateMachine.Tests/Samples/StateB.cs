using System;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateB : IState
    {
        public Action Reached15 { get; set; }

        public void Execute(IData data)
        {
            if (App.Worker.Value >= 15)
            {
                Reached15();
            }
        }
    }
}