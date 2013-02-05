using StateMachine;
using StateMachine.Processing;

namespace Game.States
{
    public abstract class GameState : IState
    {
        public void Execute(IData data)
        {
            var command = (Command) data;
            Execute(command);
        }

        public abstract void Execute(Command command);
    }
}
