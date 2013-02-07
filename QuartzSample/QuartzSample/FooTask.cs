using Quartz;
using Quartz.Impl;

namespace QuartzSample
{
    public class FooTask
    {
        private readonly IScheduler _scheduler;

        public FooTask()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();

            var fooDetail = JobBuilder
                .Create<FooJob>()
                .WithIdentity("fooJob1", "group1")
                .Build();

            var fooTrigger = TriggerBuilder
                .Create()
                .WithIdentity("fooTrigger1", "group1")
                .WithDailyTimeIntervalSchedule(x => x.WithIntervalInSeconds(5))
                .Build();

            _scheduler.ScheduleJob(fooDetail, fooTrigger);
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