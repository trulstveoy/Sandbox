using System;
using StateMachine.Processing;

namespace Runner.Samples
{
    public class FooData : IData
    {
        public Guid Id { get; set; }
        public int Counter { get; set; }
    }
}