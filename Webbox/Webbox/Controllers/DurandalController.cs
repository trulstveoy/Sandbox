using System.Web.Mvc;

namespace Webbox.Controllers 
{
  public class DurandalController : Controller 
  {
    public ActionResult Index()
    {
        var user = User;
        string name = user.Identity.Name;

        return View();
    }
  }
}