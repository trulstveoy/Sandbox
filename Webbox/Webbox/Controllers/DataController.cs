using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using Webbox.Models;

namespace Webbox.Controllers
{
    public class DataController : ApiController
    {
        private readonly List<Item> _items = new List<Item>(); 

        public DataController()
        {
            for (int i = 0; i < 10; i++)
            {
                _items.Add(new Item() {Number = i});
            }
        }

        // GET api/data
        public IEnumerable<Item> Get()
        {
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
