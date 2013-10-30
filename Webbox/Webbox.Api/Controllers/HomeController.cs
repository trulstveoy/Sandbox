using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using Webbox.Api.Models;

namespace Webbox.Api.Controllers
{
    public class HomeController : ApiController
    {
        private readonly List<Item> _items = new List<Item>();

        public HomeController()
        {
            for (int i = 0; i < 10; i++)
            {
                _items.Add(new Item() { Number = i });
            }
        }

        // GET api/data
        public IEnumerable<Item> Get()
        {
            Debug.WriteLine(User.Identity.Name);

            return _items;
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
