using System.Security.Principal;

namespace Webbox.Core.Web.Security
{
    public class WebboxIdentity : IIdentity
    {
        public WebboxIdentity(string name)
        {
            Name = name;
            AuthenticationType = "WebboxAuth";
            IsAuthenticated = true;
        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}