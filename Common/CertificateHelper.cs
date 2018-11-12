using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Sky.SelfServe.Common
{
    internal static class CertificateHelper
    {
        internal static X509Certificate2 FindCertificateByThumbprint(string thumbprint)
        {
            if (string.IsNullOrEmpty(thumbprint))
            {
                throw new ArgumentNullException("thumbprint");
            }

            thumbprint = Regex.Replace(thumbprint, @"[^\da-zA-z]", string.Empty).ToUpper();
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

            if (col.Count == 0)
            {
                return null;
            }

            return col[0];
        }
    }
}
