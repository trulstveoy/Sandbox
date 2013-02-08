using System;
using Quartz;

namespace QuartzSample
{
    public class FooJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var trigger = (ICronTrigger) context.Trigger;

            Console.WriteLine("Job executing with expression: {0}. Time is: {1}", trigger.CronExpressionString, DateTime.Now);
        }
    }
}