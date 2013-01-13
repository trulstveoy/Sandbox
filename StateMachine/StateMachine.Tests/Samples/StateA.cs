using System;

namespace StateMachine.Tests.Samples
{
    public class StateA : State
    {
        public Action Reached5 { get; set; }
        public Action Reaced10 { get; set; }

        public override void Execute()
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