using StructureMap;
using Topshelf;

namespace ServiceHost
{
    public abstract class ProgramBase<T>  where T : IService
    {
        protected void Run()
        {
            ObjectFactory.Initialize(Bootstrap);

            HostFactory.Run(configurator =>
            {
                configurator.Service<IService>(service =>
                {
                    service.ConstructUsing(s => ObjectFactory.GetInstance<T>());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configurator.RunAsLocalSystem();
                configurator.SetDescription("Quartz.Net/Topshelf sample");
                configurator.SetDisplayName("Quartz sample");
                configurator.SetServiceName("QuartzSample");
            });
        }

        protected abstract void Bootstrap(IInitializationExpression init);
    }
}
