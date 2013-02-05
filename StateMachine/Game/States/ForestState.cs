using StateMachine;
using StateMachine.Processing;

namespace Game.States
{
    public class ForestState : GameState
    {
        public Event GoneSouth = new Event();

        public override void Execute(Command command)
        {
            if(command.Text == "s")
                GoneSouth.Set();
        }
    }
}
