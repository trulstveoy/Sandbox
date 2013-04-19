using NServiceBus;

namespace NServiceBusClient 
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
	{
	    public void Init()
	    {
	        Configure.With()
	                 .DefaultBuilder()
                     .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("NServiceBusMessages") && t.Name.EndsWith("Command"));
	    }
	}
}