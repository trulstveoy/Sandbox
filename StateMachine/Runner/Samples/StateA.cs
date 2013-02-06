using System.Diagnostics;
using StateMachine;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class StateA : State
    {
        public Event Reached5 = new Event();
        public Event Reaced10 = new Event();

        public override void Execute(IData data)
        {
            var fooData = (FooData) data;

            if (fooData.Counter >= 5)
            {
                Debug.WriteLine("StateA: Reached5");
                Reached5.Set();
            }

            if (fooData.Counter >= 10)
            {
                Debug.WriteLine("StateA: Reached10");
                Reaced10.Set();
            }
        }
    }
}