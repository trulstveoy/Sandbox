namespace Publisher1
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DisableTimeoutManager()
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("Messages"));
        }
    }
}
