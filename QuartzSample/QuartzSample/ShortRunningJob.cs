using System;
using Quartz;

namespace QuartzSample
{
    [DisallowConcurrentExecution]
    public class ShortRunningJob : IJob
    {
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
        }
    }
}