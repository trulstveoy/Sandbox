using Quartz;
using Quartz.Impl;

namespace ServiceHost
{
    public class Service<T> where T : IJob
    {
        private readonly IScheduler _scheduler;

        public Service(string scheduleExpression)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();
            _scheduler.JobFactory = new JobFactory();

            var jobBuilder = JobBuilder
                .Create<T>()
                .WithIdentity("thejob")
                .Build();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity("thetrigger")
                .WithCronSchedule(scheduleExpression)
                .Build();

            _scheduler.ScheduleJob(jobBuilder, trigger);
        }

        public void Start()
        {
            _scheduler.Start();
        }

        public void Stop()
        {
            _scheduler.Shutdown();
        }
    }
}