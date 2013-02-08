using System;
using Quartz;
using ServiceHost;
using StructureMap;

namespace QuartzSample
{
    public class Program : ProgramBase<ShortRunningJob>
    {
        //Service hosting + graceful shutdown / quartz / logging

        private const string Every10Seconds = "0/10 * * 1/1 * ? *";

        static void Main()
        {
            Console.WriteLine("Quartz.Net/Topshelf/StructureMap/Log4Net sample");

            new Program().Run();
        }

        protected override void Bootstrap(IInitializationExpression init)
        {
            init.For<IJob>().Use<ShortRunningJob>();
        }

        protected override string ScheduleExpression { get { return Every10Seconds; } }

        protected override string InstanceName
        {
            get { return "QuartzSample"; }
        }
    }
}
