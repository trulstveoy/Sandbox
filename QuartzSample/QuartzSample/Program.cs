using System;
using ServiceHost;
using StructureMap;

namespace QuartzSample
{
    public class Program : ProgramBase<IFooService>
    {
        //Service hosting + graceful shutdown / quartz / logging

        static void Main()
        {
            Console.WriteLine("Quartz.Net/Topshelf/StructureMap/Log4Net sample");

            new Program().Run();
        }

        protected override void Bootstrap(IInitializationExpression init)
        {
            init.For<IFooService>().Use<FooService>();
        }
    }
}
