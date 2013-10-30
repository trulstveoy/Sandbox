using System.Web.Mvc;

namespace Webbox.Controllers 
{
  public class DurandalController : Controller 
  {
    public ActionResult Index()
    {
        var user = User;
        string username = user.Identity.Name;

        ViewBag.Username = username;
        return View();
    }
  }
}