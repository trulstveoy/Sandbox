using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using Webbox.Models;

namespace Webbox.Controllers
{
    public class RelayController : ApiController
    {
        private string ExtractSamlToken(BootstrapContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.Token))
            {
                return context.Token;
            }
               
            var req = new SamlSecurityTokenRequirement();
            var handler = new SamlSecurityTokenHandler(req);;
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                handler.WriteToken(writer, context.SecurityToken);
            }

            return sb.ToString();
        }

        // GET api/data
        public async Task<List<Item>> Get()
        {
            const string url = "http://localhost:5003/api/home";

            try
            {
                var identity = (ClaimsIdentity) User.Identity;
                var bootstrapContext = (BootstrapContext) identity.BootstrapContext;

                string rawToken = ExtractSamlToken(bootstrapContext);
                
                var bytes = Encoding.UTF8.GetBytes(rawToken);
                var base64Token = Convert.ToBase64String(bytes);

                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "bearer " + base64Token);
                        Task<string> stringAsync = client.GetStringAsync(url);
                        string itemsJson = await stringAsync;
                        var items = JsonConvert.DeserializeObject<List<Item>>(itemsJson);
                        return items;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
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
