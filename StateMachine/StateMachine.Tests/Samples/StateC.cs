using System;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateC : IState
    {
        public Action Reached20 { get; set; }
        
        public void Execute(IData data)
        {
            if (App.Worker.Value == 20)
            {
                Reached20();
            }
        }
    }
}