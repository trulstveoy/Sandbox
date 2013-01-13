using System;

namespace StateMachine.Tests.Samples
{
    public class StateC : State
    {
        public Action Reached20 { get; set; }

        public override void Execute()
        {
            if (App.Worker.Value == 20)
            {
                Reached20();
            }
        }
    }
}