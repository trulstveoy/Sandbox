using System.IdentityModel.Services;
using System.Web;

namespace Webbox.Core.Web.Security
{
    public class WebboxSessionAuthenticationModule : SessionAuthenticationModule
    {
        protected override void InitializeModule(HttpApplication context)
        {
            //do nothing - it's disabled
        }
    }
}