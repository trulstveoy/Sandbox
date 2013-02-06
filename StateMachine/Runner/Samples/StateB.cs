using System.Diagnostics;
using StateMachine;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class StateB : State
    {
        public Event Reached15 = new Event();

        public override void Execute(IData data)
        {
            var fooData = (FooData) data;

            if (fooData.Counter >= 15)
            {
                Debug.WriteLine("StateB: Reached15");
                Reached15.Set();
            }
        }
    }
}