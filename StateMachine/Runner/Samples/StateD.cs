using System.Diagnostics;
using StateMachine;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class StateD : IState
    {
        public void Execute(IData data)
        {
            var fooData = (FooData) data;

            Debug.WriteLine("StateD");
        }
    }
}