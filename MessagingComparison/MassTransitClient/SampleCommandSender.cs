using System;
using System.Globalization;
using MassTransit;
using MassTransitCommands;
using MassTransitHost;

namespace MassTransitClient
{
    public class SampleCommandSender : ISendCommand
    {
        public void Start(IServiceBus serviceBus)
        {
            Console.WriteLine("Press any key to send command, q to quit");

            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
                serviceBus.GetEndpoint(new MessageUrn(string.Format("msmq://localhost/{0}", "FooBarServer"))).Send(new SampleCommand { Text = key.ToString(CultureInfo.InvariantCulture) });

            } while (key != 'q');

            Console.WriteLine("Publish completed.");

            
        }
    }
}