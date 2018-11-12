using System;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sky.SelfServe.Common
{
    public class KeyVaultClientBuilder
    {
        private string thumbprint;
        private string clientId;

        public KeyVaultClientBuilder UseThumbprint(string thumbprint)
        {
            if (string.IsNullOrEmpty(thumbprint))
            {
                throw new ArgumentNullException(nameof(thumbprint));
            }

            this.thumbprint = thumbprint;
            return this;
        }

        public KeyVaultClientBuilder UseClientId(string clientId)
        {
            if (string.IsNullOrEmpty(thumbprint))
            {
                throw new ArgumentNullException(nameof(thumbprint));
            }

            this.clientId = clientId;
            return this;
        }

        public KeyVaultClient Build()
        {
            return new KeyVaultClient(AuthenticationCallback());
        }

        private KeyVaultClient.AuthenticationCallback AuthenticationCallback()
        {
            var assertionCertificate = CreateAssertionCertificate();
            return async (authority, resource, scope) =>
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                var result = await context.AcquireTokenAsync(resource, assertionCertificate);
                return result.AccessToken;
            };
        }

        private ClientAssertionCertificate CreateAssertionCertificate()
        {
            var clientAssertionCertPfx = CertificateHelper.FindCertificateByThumbprint(thumbprint);
            if (clientAssertionCertPfx == null)
            {
                throw new InvalidOperationException("not found Certificate");
            }

            return new ClientAssertionCertificate(clientId, clientAssertionCertPfx);
        }
    }
}
