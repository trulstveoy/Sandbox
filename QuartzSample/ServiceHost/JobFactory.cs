using Quartz;
using Quartz.Spi;
using StructureMap;

namespace ServiceHost
{
    public class JobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)ObjectFactory.GetInstance(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {}
    }
}