using System;
using System.Diagnostics;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateC : State
    {
        public Event Reached20 = new Event();

        public override void Execute(IData data)
        {
            if (App.Worker.Value == 20)
            {
                Debug.WriteLine("Reached20");
                Reached20.Set();
            }
        }
    }
}