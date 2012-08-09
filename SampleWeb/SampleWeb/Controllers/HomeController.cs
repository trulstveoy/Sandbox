namespace SampleWeb.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Models;

    public class HomeController : Controller
    {
        private readonly Entities _entities = new Entities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var products =
                from p in _entities.Products
                select p;

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

    }
}
