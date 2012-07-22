namespace Subscriber1
{
    using NServiceBus.Config;
    using NServiceBus.Config.ConfigurationSource;

    public class ConfigOverride : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
                       {
                           ErrorQueue = "error"
                       };
        }
    }
}