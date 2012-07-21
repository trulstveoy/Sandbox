namespace Publisher1
{
    using System;
    using Messages;
    using NServiceBus;

    public class ServerEndpoint : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            Console.WriteLine("This will publish IEvent and EventMessage alternately.");
            Console.WriteLine("Press 'Enter' to publish a message.To exit, Ctrl + C");

            bool publishIEvent = true;
            while (Console.ReadLine() != null)
            {
                var eventMessage = publishIEvent ? Bus.CreateInstance<IEventMessage1>() : new EventMessage1();

                eventMessage.Text = DateTime.Now.ToString();

                Bus.Publish(eventMessage);

                Console.WriteLine("Published event with text {0}.", eventMessage.Text);
                Console.WriteLine("==========================================================================");

                publishIEvent = !publishIEvent;
            }
                
        }

        public void Stop()
        {

        }
    }
}