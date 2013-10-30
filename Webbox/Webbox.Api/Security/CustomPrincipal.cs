using System.Security.Principal;

namespace Webbox.Api.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal()
        {
            Identity = new CustomIdentity();
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; private set; }
    }

    public class CustomIdentity : IIdentity
    {
        public CustomIdentity()
        {
            Name = "Trulsemann";
            AuthenticationType = "Custom";
            IsAuthenticated = true;
        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}