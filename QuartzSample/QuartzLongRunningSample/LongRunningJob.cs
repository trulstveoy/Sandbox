using System;
using System.Threading;
using Quartz;

namespace QuartzLongRunningSample
{
    [DisallowConcurrentExecution]
    public class LongRunningJob : IJob
    {
        private readonly IDependency _dependency;

        public LongRunningJob(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void Execute(IJobExecutionContext context)
        {
            var cronTrigger = context.Trigger as ICronTrigger;
            if (cronTrigger != null)
            {
                var trigger = cronTrigger;

                Console.WriteLine("Job executing with expression: {0}. Time is: {1}", trigger.CronExpressionString, DateTime.Now);
            }
            else
            {
                Console.WriteLine("Job executing on demand. Time is: {0}", DateTime.Now);
                context.Scheduler.UnscheduleJob(context.Trigger.Key);
            }

            Console.WriteLine("About to sleep 30 seconds....");
            for (int i = 0; i < 30; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Woke up!");
        }
    }
}