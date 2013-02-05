using System.Web.Http;
using Game;

namespace WebFrontend.Controllers
{
    public class GameController : ApiController
    {
        private readonly Engine _engine = new Engine();

        public string GetInitialMessage()
        {
            return _engine.GetFirstMessage();
        }

        public string GetNextMessage(string command)
        {
            return _engine.ExecuteCommand(command);
        }
    }
}
