using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace DevSTS.Security
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public CustomIdentity(string name)
        {
            Name = name;
            AuthenticationType = "Custom";
            IsAuthenticated = true;
        }
    }
}