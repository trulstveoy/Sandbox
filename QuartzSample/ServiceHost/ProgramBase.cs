using Quartz;
using StructureMap;
using Topshelf;

namespace ServiceHost
{
    public abstract class ProgramBase<T>  where T : IJob
    {
        protected abstract void Bootstrap(IInitializationExpression init);
        protected abstract string ScheduleExpression { get; }
        protected abstract string InstanceName { get; }

        protected void Run()
        {
            ObjectFactory.Initialize(Bootstrap);

            HostFactory.Run(configurator =>
            {
                configurator.Service<Service<T>>(service =>
                {
                    service.ConstructUsing(s => new Service<T>(InstanceName, ScheduleExpression));
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configurator.RunAsLocalSystem();
                configurator.SetDescription("Quartz.Net/Topshelf sample");
                configurator.SetDisplayName("Quartz.Net/Topshelf sample");
                configurator.SetServiceName("QuartzNetTopshelfSample");
            });
        }
    }
}
