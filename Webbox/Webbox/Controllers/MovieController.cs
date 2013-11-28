using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Webbox.DataAccess;
using Webbox.DataAccess.Dtos;

namespace Webbox.Controllers
{
    public class MovieController : ApiController
    {
        public IEnumerable<Movie> Get()
        {
            using (var db = new WebboxContext())
            {
                var movies = from m in db.Movies 
                            select m;

                return movies.ToList();
            }
        }
    }
}
