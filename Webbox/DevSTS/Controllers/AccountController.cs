using System.Collections.Specialized;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevSTS.Security;

namespace DevSTS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var querystring = Request.QueryString.ToString();
            NameValueCollection items = HttpUtility.ParseQueryString(Request.QueryString["wctx"]);
            string item = items["ru"].ToLower();
            int index = item.IndexOf("extlogin", System.StringComparison.Ordinal);

            string url = Url.Action(index == -1 ? "WinLogin" : "UsernameLogin");

            return Redirect(url + "?" + querystring);
        }
        
        public ActionResult WinLogin()
        {
            var request = System.Web.HttpContext.Current.Request;
            var response = System.Web.HttpContext.Current.Response;

            var user = (ClaimsPrincipal)User;

            FederatedPassiveSecurityTokenServiceOperations.ProcessRequest(request, user, CustomSecurityTokenServiceConfiguration.Current.CreateSecurityTokenService(), response);
            return new EmptyResult();
        }

        [AllowAnonymous]
        public ActionResult UsernameLogin()
        {
            NameValueCollection items = HttpUtility.ParseQueryString(Request.QueryString["wctx"]);
            string item = items["ru"].ToLower();
            int index = item.IndexOf("extlogin", System.StringComparison.Ordinal);
            string username = item.Substring(index+9);

            var request = System.Web.HttpContext.Current.Request;
            var response = System.Web.HttpContext.Current.Response;

            var identity = new CustomIdentity(username);
            var user = new ClaimsPrincipal(identity);

            FederatedPassiveSecurityTokenServiceOperations.ProcessRequest(request, user, CustomSecurityTokenServiceConfiguration.Current.CreateSecurityTokenService(), response);
            return new EmptyResult();
        }
    }
}
