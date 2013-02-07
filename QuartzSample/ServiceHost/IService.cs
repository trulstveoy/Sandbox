using Quartz;

namespace ServiceHost
{
    public interface IService : IJob
    {
        void Start();
        void Stop();
    }
}