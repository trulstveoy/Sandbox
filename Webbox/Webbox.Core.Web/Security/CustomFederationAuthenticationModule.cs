using System;
using System.Collections.Specialized;
using System.IdentityModel.Services;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace Webbox.Core.Web.Security
{
    public class CustomFederationAuthenticationModule : WSFederationAuthenticationModule
    {
        protected override void OnAuthenticateRequest(object sender, EventArgs args)
        {
            var application = (HttpApplication)sender;
            if (RetrieveCookie(application))
            {
                return;
            }

            base.OnAuthenticateRequest(sender, args);

            SetCookie(application);
        }

        private static void SetCookie(HttpApplication application)
        {
            var claimsPrincipal = application.User as ClaimsPrincipal;
            if (claimsPrincipal != null && claimsPrincipal.Identity.IsAuthenticated)
            {
                var cookie = new HttpCookie("WebboxAuth");
                var bytes = Encoding.UTF8.GetBytes(claimsPrincipal.Identity.Name);
                byte[] encrypted = MachineKey.Protect(bytes);
                var base64 = Convert.ToBase64String(encrypted);
                cookie.Value = base64;
                cookie.Expires = DateTime.Now.AddDays(30);
                cookie.Shareable = false;

                application.Response.Cookies.Clear();
                application.Response.SetCookie(cookie);
            }
        }

        private static bool RetrieveCookie(HttpApplication application)
        {
            if (application.Request.Cookies.AllKeys.Contains("WebboxAuth"))
            {
                var cookie = application.Request.Cookies["WebboxAuth"];
                var base64 = cookie.Value;
                var encrypted = Convert.FromBase64String(base64);
                byte[] decrypted = MachineKey.Unprotect(encrypted);
                string name = Encoding.UTF8.GetString(decrypted);

                var principal = new WebboxPrincipal(name);
                Thread.CurrentPrincipal = principal;
                application.Context.User = principal;
                return true;
            }
            return false;
        }
    }
}