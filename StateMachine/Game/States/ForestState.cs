using System;
using StateMachine;
using StateMachine.Processing;

namespace Game.States
{
    [Serializable]
    public class ForestState : GameState
    {
        public Event GoneSouth = new Event();

        public override string Message { get; set; }

        public ForestState()
        {
            Message = "You're in the forest... You can go south.";
        }

        public override void Execute(Command command)
        {
            if(command.Text == "s")
                GoneSouth.Set();
        }
    }
}
