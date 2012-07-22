namespace Subscriber1
{
    using System;
    using Messages;
    using NServiceBus;
    using log4net;

    public class EventMessage1Handler : IHandleMessages<EventMessage1>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(EventMessage1Handler));

        public void Handle(EventMessage1 message)
        {
            Console.WriteLine(message.Text);    
        }
    }
}