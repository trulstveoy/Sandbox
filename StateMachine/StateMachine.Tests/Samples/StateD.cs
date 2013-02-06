using System.Diagnostics;
using StateMachine.Processing;

namespace StateMachine.Tests.Samples
{
    public class StateD : State
    {
        public override void Execute(IData data)
        {
            Debug.WriteLine("StateD");
        }
    }
}