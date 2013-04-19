using System;
using System.Globalization;
using NServiceBus;
using NServiceBusMessages;

namespace NServiceBusClient
{
    public class PublisherEndpoint : IWantToRunAtStartup
    {
        private readonly IBus _bus;

        public PublisherEndpoint(IBus bus)
        {
            _bus = bus;
        }

        public void Run()
        {
            Console.WriteLine("Press any key to send command, q to quit");

            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
                var message = _bus.CreateInstance<ISampleCommand>();
                message.Text = key.ToString(CultureInfo.InvariantCulture);
                _bus.Send(message);

            } while (key != 'q');

            Console.WriteLine("Publish completed.");
        }

        public void Stop()
        {}
    }
}