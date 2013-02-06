using System.Diagnostics;
using StateMachine;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class StateD : State
    {
        public override void Execute(IData data)
        {
            var fooData = (FooData) data;

            Debug.WriteLine("StateD");
        }
    }
}