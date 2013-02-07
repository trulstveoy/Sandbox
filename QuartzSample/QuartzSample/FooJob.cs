using System;
using Quartz;

namespace QuartzSample
{
    public class FooJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("FooJob executing.... Time is: {0}", DateTime.Now);
        }
    }
}