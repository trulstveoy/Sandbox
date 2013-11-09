using System.Web.Http;
using Webbox.Core.Logging;
using Webbox.Models;

namespace Webbox.Controllers
{
    public class LoggingController : ApiController
    {
        private const string Error = "Error";
        private const string Info = "Info";
        private const string Debug = "Debug";

        // POST api/logging
        public void Post([FromBody] LogContent content)
        {
            
            var log = WebboxLog.LogFor(content.Name);

            switch (content.Severity)
            {
                case Error:
                    log.Error(content.Message);
                    break;

                case Info:
                    log.Info(content.Message);
                    break;

                case Debug:
                    log.Debug(content.Message);
                    break;
                
                default:
                    log.Info("Invalid severity - defaulting to Info");
                    log.Info(content.Message);
                    break;
            }
        }
    }
}
