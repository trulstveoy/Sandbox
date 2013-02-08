using System;
using System.Collections.Specialized;
using Quartz;
using Quartz.Collection;
using Quartz.Impl;

namespace JobModifier
{
    class Program
    {
        private const string Every2Seconds = "0/2 * * 1/1 * ? *";
        private const string Every5Seconds = "0/5 * * 1/1 * ? *";

        private const string RunOnceTriggerName = "runoncetrigger";
        private const string InstanceName = "QuartzSample";
        private const string TriggerName = "QuartzSample_trigger";
        private const string JobName = "QuartzSample_job";

        static void Main()
        {
            var properties = new NameValueCollection();
            properties.Add("quartz.scheduler.instanceName", InstanceName);
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

            char keyChar;
            do
            {
                Console.WriteLine("Modifies Quartz.Net job. Now you can:");
                Console.WriteLine("Create trigger? (1)");
                Console.WriteLine("Remove trigger? (2)");
                Console.WriteLine("Reschedule trigger? (3)");
                Console.WriteLine("Run job once? (4)");

                Console.WriteLine("Quit? (q)");

                var consoleKeyInfo = Console.ReadKey();
                keyChar = consoleKeyInfo.KeyChar;
                
                if (keyChar == '1')
                {
                    NewTrigger(schedulerFactory);
                }
                else if (keyChar == '2')
                {
                    RemoveTrigger(schedulerFactory);
                }
                else if (keyChar == '3')
                {
                    Reschedule(schedulerFactory);
                }
                else if (keyChar == '4')
                {
                    RunOnce(schedulerFactory);
                }
                else
                {
                    Console.WriteLine("Wrong key....");
                }
            } while (keyChar != 'q');

            Console.WriteLine("Quit...");
        }

        private static void RemoveTrigger(ISchedulerFactory schedulerFactory)
        {
            Console.WriteLine("Remove trigger...");

            var scheduler = schedulerFactory.GetScheduler();

            scheduler.UnscheduleJob(new TriggerKey(TriggerName));
        }

        private static void NewTrigger(ISchedulerFactory schedulerFactory)
        {
            Console.WriteLine("New trigger...");

            var scheduler = schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(TriggerName)
                    .ForJob(new JobKey(JobName))
                    .WithCronSchedule(Every2Seconds)
                    .Build();

            scheduler.ScheduleJob(trigger);
        }

        private static void Reschedule(ISchedulerFactory schedulerFactory)
        {
            Console.WriteLine("Reschedule trigger...");

            var scheduler = schedulerFactory.GetScheduler();
            scheduler.UnscheduleJob(new TriggerKey(TriggerName));

            var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(TriggerName)
                    .ForJob(new JobKey(JobName))
                    .WithCronSchedule(Every5Seconds)
                    .Build();

            scheduler.ScheduleJob(trigger);
        }

        private static void RunOnce(ISchedulerFactory schedulerFactory)
        {
            Console.WriteLine("Running once....");

            var scheduler = schedulerFactory.GetScheduler();

            var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(RunOnceTriggerName)
                    .ForJob(new JobKey(JobName))
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(1))
                    .Build();

            scheduler.ScheduleJob(trigger);
        }
    }
}
