using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using Newtonsoft.Json;
using NLog;
using Webbox.Core.Logging;
using Webbox.Models;

namespace Webbox.Controllers
{
    public class RelayController : ApiController
    {
        private static readonly Logger Log = WebboxLog.LogFor<RelayController>();

        // GET api/data
        public async Task<List<Item>> Get()
        {
            Log.Debug("About to relay...");
            const string url = "http://localhost:5003/api/home";

            try
            {
                var bytes = Encoding.UTF8.GetBytes(User.Identity.Name);
                byte[] encrypted = MachineKey.Protect(bytes);
                var base64 = Convert.ToBase64String(encrypted);
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("WebboxAuth", base64);
                        Task<string> stringAsync = client.GetStringAsync(url);
                        string itemsJson = await stringAsync;
                        var items = JsonConvert.DeserializeObject<List<Item>>(itemsJson);
                        return items;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        // GET api/data/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/data
        public void Post([FromBody]string value)
        {
        }

        // PUT api/data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/data/5
        public void Delete(int id)
        {
        }
    }
}
