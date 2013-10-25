using System;
using System.Configuration;
using System.IdentityModel.Configuration;
using System.IdentityModel.Metadata;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace DevSTS.Security
{
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        private static readonly object SyncRoot = new object();
        private const string CustomSecurityTokenServiceConfigurationKey = "CustomSecurityTokenServiceConfigurationKey";


        public CustomSecurityTokenServiceConfiguration() 
            : base(Constants.IssuerName)
        {
            TokenIssuerName = Constants.IssuerName;
            string signingCertificatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.SigningCertificate);
            var signignCert = new X509Certificate2(signingCertificatePath, Constants.SigningCertificatePassword, X509KeyStorageFlags.PersistKeySet);
            SigningCredentials = new X509SigningCredentials(signignCert);
            ServiceCertificate = signignCert;
            SecurityTokenService = typeof(CustomSecurityTokenService);
        }

        public static CustomSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;
                var myConfiguration = httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as CustomSecurityTokenServiceConfiguration;

                if (myConfiguration != null)
                {
                    return myConfiguration;
                }

                lock (SyncRoot)
                {
                    myConfiguration = httpAppState.Get(CustomSecurityTokenServiceConfigurationKey) as CustomSecurityTokenServiceConfiguration;

                    if (myConfiguration == null)
                    {
                        myConfiguration = new CustomSecurityTokenServiceConfiguration();
                        httpAppState.Add(CustomSecurityTokenServiceConfigurationKey, myConfiguration);
                    }

                    return myConfiguration;
                }
            }
        }
    }
}