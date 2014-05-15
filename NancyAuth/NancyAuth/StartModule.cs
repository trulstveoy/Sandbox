using Nancy;

namespace NancyAuth
{
    public class StartModule : NancyModule
    {
        public StartModule()
        {
            Get["/"] = parameters => "Hello world";
        }
    }
}