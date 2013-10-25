using System;
using System.Security.Cryptography.X509Certificates;

namespace DevSTS.Security
{
    public class CertificateUtil
    {
        /// <summary>
        /// Get the certificate from a specific store/location/subject.
        /// </summary>
        public static X509Certificate2 GetCertificate(StoreName name, StoreLocation location, string friendlyName)
        {
            var store = new X509Store(name, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                X509Certificate2 result = null;
                certificates = store.Certificates;

                for (int i = 0; i < certificates.Count; i++)
                {
                    X509Certificate2 cert = certificates[i];

                    if (cert.FriendlyName.ToLower() == friendlyName.ToLower())
                    {
                        if (result != null)
                        {
                            throw new ApplicationException(string.Format("More than one certificate was found for friendly Name {0}", friendlyName));
                        }

                        result = new X509Certificate2(cert);
                    }
                }

                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for friendly Name {0}", friendlyName));
                }

                return result;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }

                store.Close();
            }
        }
    }
}