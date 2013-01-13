using System;

namespace StateMachine.Tests.Samples
{
    public class StateB : State
    {
        public Action Reached15 { get; set; }

        public override void Execute()
        {
            if (App.Worker.Value >= 15)
            {
                Reached15();
            }
        }
    }
}