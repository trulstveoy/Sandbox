using Quartz;
using StructureMap;
using Topshelf;

namespace ServiceHost
{
    public abstract class ProgramBase<T>  where T : IJob
    {
        protected void Run()
        {
            ObjectFactory.Initialize(Bootstrap);

            HostFactory.Run(configurator =>
            {
                configurator.Service<Service<T>>(service =>
                {
                    service.ConstructUsing(s => new Service<T>());
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
