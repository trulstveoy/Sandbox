using MassTransit;
using MassTransitHost;

namespace MassTransitClient
{
    public class MessagePublisher : IPublisher
    {
        private readonly IServiceBus _bus;

        public MessagePublisher()
        {
            //_bus = ServiceBusFactory.New(configurator =>
            //{
            //    configurator.UseMsmq();
            //});
        }

        public void Publish(string text)
        {
            //_bus.Publish(new SampleMessage() {Text = text});
        }
    }
}