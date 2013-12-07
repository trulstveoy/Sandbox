using System;
using System.Web;
using Thinktecture.IdentityModel.Clients;

namespace Webbox.Core.Web.Security
{
    public class OAuth2TokenHandlerModule : IHttpModule
    {
        private HttpApplication _context;

        public void Init(HttpApplication context)
        {
            _context = context;
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        void OnAuthenticateRequest(object sender, System.EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application != null)
            {
                var code = application.Request.QueryString["code"];
                if (!string.IsNullOrWhiteSpace(code))
                {
                    var client = new OAuth2Client(
                        new Uri("https://localhost:5009/issue/oauth2/token"), "webbox", "RWTRiezCQ5Pp2tnNRZ27XK5JELsHgH44tuijzfNjMxM=");
                    AccessTokenResponse response = client.RequestAccessTokenCode(code);

                }

                var url = OAuth2Client.CreateCodeFlowUrl(
                    "https://localhost:5009/issue/oauth2/authorize", "webbox", "http://webbox/", "https://localhost:5001/");

                _context.Response.Redirect(url);
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.AuthenticateRequest -= OnAuthenticateRequest;
            }
        }
    }
}