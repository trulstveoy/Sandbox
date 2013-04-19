namespace MassTransitHost
{
    public interface IHandleCommand
    {
        void Handle(object command);
    }
}