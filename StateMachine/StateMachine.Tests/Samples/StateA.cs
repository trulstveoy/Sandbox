using System;

namespace StateMachine.Tests.Samples
{
    public class StateA : State
    {
        public Action EventA { get; set; }
        public Action EventB { get; set; }

        public override void Execute()
        {
            if (App.Worker.Value >= 5)
            {
                
            }

            if (App.Worker.Value >= 10)
            {
                
            }
        }
    }
}