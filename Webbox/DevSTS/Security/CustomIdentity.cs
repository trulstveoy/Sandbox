using System.Security.Claims;

namespace DevSTS.Security
{
    public class CustomIdentity : ClaimsIdentity
    {
        private readonly string _name;
        public override string Name { get { return _name; } }

        private readonly bool _isAuthenticated;
        public override bool IsAuthenticated { get { return _isAuthenticated; } }

        public CustomIdentity(string name)
        {
            _name = name;
            _isAuthenticated = true;
        }
    }
}