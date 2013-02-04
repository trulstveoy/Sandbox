using System.Web.Http;

namespace WebFrontend.Controllers
{
    public class GameController : ApiController
    {
        public string GetInitialMessage()
        {
            return "hello world";
        
        }

        public string GetNextMessage(string command)
        {
            return command;
        }
    }
}
