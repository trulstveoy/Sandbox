using StateMachine.Processing;

namespace StateMachine
{
    public interface IState 
    {
        void Execute(IData data);
    }
}
