using Quartz;
using ServiceHost;
using StructureMap;

namespace QuartzLongRunningSample
{
    public class Program : ProgramBase<LongRunningJob>
    {
        private const string Every40Seconds = "0/40 * * 1/1 * ? *";

        static void Main()
        {
            new Program().Run();
        }

        protected override void Bootstrap(IInitializationExpression init)
        {
            init.For<IJob>().Use<LongRunningJob>();
            init.For<IDependency>().Use<Dependency>();
        }

        protected override string ScheduleExpression
        {
            get { return Every40Seconds; }
        }

        protected override string InstanceName
        {
            get { return "QuartzLongRunningSample"; }
        }
    }
}
