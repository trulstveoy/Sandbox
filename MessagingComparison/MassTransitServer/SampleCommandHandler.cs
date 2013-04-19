using System;
using MassTransit;
using MassTransitCommands;
using MassTransitHost;

namespace MassTransitServer
{
    public class SampleCommandHandler : IHandleCommand, IConsumer
    {
        private readonly IServiceBus _serviceBus;

        public SampleCommandHandler(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;

            _serviceBus.SubscribeHandler<SampleCommand>(Handle);
        }

        public void Handle(object command)
        {
            var sampleCommand = (SampleCommand)command;
            Console.WriteLine("{0}: {1}", DateTime.Now, sampleCommand.Text);    
        }
    }
}