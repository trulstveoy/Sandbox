using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;

namespace ServiceHost
{
    public class Service<T> where T : IJob
    {
        private readonly string _instanceName;
        private readonly string _scheduleExpression;
        private readonly IScheduler _scheduler;

        public Service(string instanceName, string scheduleExpression)
        {
            _instanceName = instanceName;
            _scheduleExpression = scheduleExpression;

            var properties = new NameValueCollection();
            properties.Add("quartz.scheduler.instanceName", instanceName);
            properties.Add("quartz.scheduler.idleWaitTime", "3000");

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

            ConfigureJob();
            ConfigureTrigger();
        }

        private void ConfigureTrigger()
        {
            if (_scheduler.GetTrigger(new TriggerKey(_instanceName + "_trigger")) == null)
            {
                var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(_instanceName + "_trigger")
                    .ForJob(new JobKey(_instanceName + "_job"))
                    .WithCronSchedule(_scheduleExpression)
                    .Build();
                _scheduler.ScheduleJob(trigger);
            }
        }

        private void ConfigureJob()
        {
            IJobDetail jobDetail = _scheduler.GetJobDetail(new JobKey(_instanceName + "_job"));
            if (jobDetail == null)
            {
                jobDetail = JobBuilder
                    .Create<T>()
                    .StoreDurably(true)
                    .WithIdentity(_instanceName + "_job")
                    .Build();

                _scheduler.AddJob(jobDetail, true);
            }
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