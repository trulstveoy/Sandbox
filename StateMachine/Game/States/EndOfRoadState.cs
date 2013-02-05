using StateMachine;

namespace Game.States
{
    public class EndOfRoadState : GameState
    {
        public Event GoneNorth = new Event();

        public override void Execute(Command command)
        {
            if(command.Text == "n")
                GoneNorth.Set();
        }
    }
}