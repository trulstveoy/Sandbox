using Quartz;
using ServiceHost;

namespace QuartzSample
{
    public interface IFooService : IService
    {}

    public class FooService : IFooService
    {
        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public void Execute(IJobExecutionContext context)
        {
            
        }
    }
}