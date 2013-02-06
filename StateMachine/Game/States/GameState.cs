using System;
using StateMachine;
using StateMachine.Processing;

namespace Game.States
{
    [Serializable]
    public abstract class GameState : State
    {
        public abstract string Message { get; set; }

        public override void Execute(IData data)
        {
            var command = (Command) data;
            Execute(command);
        }

        public abstract void Execute(Command command);
    }
}
