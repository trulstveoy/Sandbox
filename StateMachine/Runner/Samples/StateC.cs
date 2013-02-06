using System.Diagnostics;
using StateMachine;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class StateC : State
    {
        public Event Reached20 = new Event();

        public override void Execute(IData data)
        {
            var fooData = (FooData) data;

            if (fooData.Counter == 20)
            {
                Debug.WriteLine("StateC: Reached20");
                Reached20.Set();
            }
        }
    }
}