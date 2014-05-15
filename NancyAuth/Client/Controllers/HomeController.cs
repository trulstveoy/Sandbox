using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var cookie = new HttpCookie("Auth");
            cookie.Value = "The quick brown fox";
            Response.Cookies.Add(cookie);

            return View();
        }
    }
}
