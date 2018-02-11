using Microsoft.IdentityModel.S2S.Protocols.OAuth2;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SharePoint.Client;
using System;
using System.Configuration;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;

namespace Accesa.ServiceDeskWeb
{
    public static class SharePointContextProvider
    {
        public static ClientContext GetContext()
        {
            var context = new ClientContext(ConfigurationManager.AppSettings["SPOWebUrl"]);

            context.AuthenticationMode = ClientAuthenticationMode.Default;
            context.Credentials = new SharePointOnlineCredentials(GetSPOAccountName(), GetSPOSecureStringPassword());
            context.ExecuteQuery();
            return context;
        }

        private static SecureString GetSPOSecureStringPassword()
        {
            var secureString = new SecureString();

            foreach (char c in ConfigurationManager.AppSettings["SPOPassword"])
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

        private static string GetSPOAccountName()
        {
            return ConfigurationManager.AppSettings["SPOAccount"];
        }
    }
}
