using System;
using StateMachine.Processing;

namespace Game
{
    public class Command : IData
    {
        public Guid Id { get; set; }
        public string Text { get; private set; }

        public Command(string text)
        {
            Text = text;
        }
    }
}