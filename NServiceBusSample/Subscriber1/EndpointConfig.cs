namespace Subscriber1
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                //this overrides the NServiceBus default convention of IEvent
                .DisableTimeoutManager()
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Messages"));
        }
    }
}

