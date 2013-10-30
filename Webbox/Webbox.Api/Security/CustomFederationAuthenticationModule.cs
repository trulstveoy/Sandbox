using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Xml;

namespace Webbox.Api.Security
{
    public class CustomFederationAuthenticationModule : WSFederationAuthenticationModule
    {
        private static bool TryRetrieveToken(HttpRequest request, out string token)
        {
            token = null;

            if (!request.Headers.AllKeys.Contains(HttpRequestHeader.Authorization.ToString()))
            {
                return false;
            }

            string bearerToken = request.Headers.Get(HttpRequestHeader.Authorization.ToString());
            if (string.IsNullOrWhiteSpace(bearerToken))
            {
                return false;
            }

            var base64Token = bearerToken.Substring(7); //starts with bearer
            byte[] bytes = Convert.FromBase64String(base64Token);
            token = System.Text.Encoding.UTF8.GetString(bytes);

            return true;
        }

        protected override void OnAuthenticateRequest(object sender, EventArgs args)
        {
            var application = (HttpApplication) sender;

            string token;
            if (TryRetrieveToken(application.Request, out token))
            {
                SecurityTokenHandlerCollection handlers = FederationConfiguration.IdentityConfiguration.SecurityTokenHandlers;
                SecurityToken securityToken = handlers.ReadToken(new XmlTextReader(new StringReader(token)));
                ReadOnlyCollection<ClaimsIdentity> claimsColletion = handlers.ValidateToken(securityToken);
                ClaimsIdentity identity = claimsColletion.First();
                var user = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = user;
                application.Context.User = user;
                return;
            }

            base.OnAuthenticateRequest(sender, args);
        }
    }
}