using System;
using System.Diagnostics;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateB : State
    {
        public Event Reached15 = new Event();

        public override void Execute(IData data)
        {
            if (App.Worker.Value >= 15)
            {
                Debug.WriteLine("Reached15");
                Reached15.Set();
            }
        }
    }
}