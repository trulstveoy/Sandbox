using System.Security.Principal;

namespace Webbox.Core.Web.Security
{
    public class WebboxPrincipal : IPrincipal
    {
        public WebboxPrincipal(string name)
        {
            Identity = new WebboxIdentity(name);
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; private set; }
    }
}