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

            while (Console.ReadLine() != null)
            {
                var eventMessage = new EventMessage1();
                eventMessage.Text = DateTime.Now.ToString();

                try
                {
                    Bus.Publish(eventMessage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("Published event with text {0}.", eventMessage.Text);
                Console.WriteLine("==========================================================================");
            }
                
        }

        public void Stop()
        {

        }
    }
}