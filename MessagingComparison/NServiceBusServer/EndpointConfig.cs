using NServiceBus;

namespace NServiceBusServer 
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                     .DefaultBuilder()
                     .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("NServiceBusMessages") && t.Name.EndsWith("Command"));


        }
    }
}