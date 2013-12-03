using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NLog;
using Webbox.Core.Logging;
using Webbox.MongoAccess;

namespace Webbox.Rpc.Controllers
{
    public class MongoController : ApiController
    {
        private static readonly Logger Log = WebboxLog.LogFor<MongoController>();

        public void Populate()
        {
            Log.Debug("About to populate Mongo");

            var gateway = new Gateway();
            gateway.PopulateMongo();
        }

        public IEnumerable<string> GetCustomerNames()
        {
            Log.Debug("Getting customer names...");

            var gateway = new Gateway();

            var customerNames = gateway.GetCustomers().Select(x => x.Name).ToList();

            Log.Debug("Retrieved {0} customer names", customerNames.Count());

            return customerNames;
        }
    }
}
