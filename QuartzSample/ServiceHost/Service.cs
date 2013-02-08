using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;

namespace ServiceHost
{
    public class Service<T> where T : IJob
    {
        private readonly IScheduler _scheduler;

        public Service(string scheduleExpression)
        {
            var properties = new NameValueCollection();
            properties.Add("quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz");
            properties.Add("quartz.jobStore.dataSource", "default");
            properties.Add("quartz.jobStore.tablePrefix", "QRTZ_");
            properties.Add("quartz.jobStore.clustered", "true");
            properties.Add("quartz.jobStore.lockHandler.type", "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz");
            properties.Add("quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz");
            properties.Add("quartz.dataSource.default.connectionString", "Server=localhost;Database=QuartzConfig;Uid=dbuser;Pwd=dbpass;");
            properties.Add("quartz.dataSource.default.provider", "SqlServer-20");
            properties.Add("quartz.jobStore.useProperties", "true");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(properties);
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