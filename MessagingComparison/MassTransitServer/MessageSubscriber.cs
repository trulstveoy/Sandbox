using System;
using MassTransit;

namespace MassTransitServer
{
    public class MessageSubscriber
    {
        private IServiceBus _bus;

        public MessageSubscriber(Action<string> onMessageReceived)
        {
            //_bus = ServiceBusFactory.New(sbc =>
            //                                 {
            //                                     sbc.UseMsmq();
            //                                     sbc.Subscribe(subs => subs.Handler<SampleMessage>(msg => onMessageReceived(msg.Text)));
            //                                 });
        }
    }
}