using MassTransit;

namespace MassTransitHost
{
    public interface ISendCommand
    {
        void Start(IServiceBus serviceBus);
    }
}