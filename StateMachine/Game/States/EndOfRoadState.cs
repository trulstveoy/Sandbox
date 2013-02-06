using System;
using StateMachine;

namespace Game.States
{
    [Serializable]
    public class EndOfRoadState : GameState
    {
        public Event GoneNorth = new Event();

        public override string Message { get; set; }

        public EndOfRoadState()
        {
            Message = "At the end of a road.... You can go north.";
        }

        public override void Execute(Command command)
        {
            if(command.Text == "n")
                GoneNorth.Set();
        }
    }
}