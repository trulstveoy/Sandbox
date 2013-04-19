using Autofac;
using MassTransitHost;

namespace MassTransitClient
{
    public class Bootstrapper : IBootstrapper
    {
        public void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<SampleCommandSender>().As<ISendCommand>();
        }
    }
}