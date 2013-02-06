using System;
using System.Diagnostics;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateA : State
    {
        public Event Reached5 = new Event();
        public Event Reaced10 = new Event();

        public override void Execute(IData data)
        {
            if (App.Worker.Value >= 5)
            {
                Debug.WriteLine("Reached5");
                Reached5.Set();
            }

            if (App.Worker.Value >= 10)
            {
                Debug.WriteLine("Reached10");
                Reaced10.Set();
            }
        }
    }
}