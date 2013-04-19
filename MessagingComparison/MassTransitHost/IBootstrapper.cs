using Autofac;

namespace MassTransitHost
{
    public interface IBootstrapper
    {
        void Initialize(ContainerBuilder builder);
    }
}