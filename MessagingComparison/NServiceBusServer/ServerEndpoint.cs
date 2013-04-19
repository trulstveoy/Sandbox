using System;
using NServiceBus.Saga;
using NServiceBusMessages;

namespace NServiceBusServer
{
    public class ServerEndpoint : IAmStartedByMessages<ISampleCommand>
    {
        public void Handle(ISampleCommand command)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now, command.Text);
        }
    }
}