using Accesa.ServiceDeskWeb.Services;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public  class SharePointArhitecture
    {
        private ClientContext context;

        public SharePointArhitecture()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public void SendEmail(EmailProperties properties)
        {
            Utility.SendEmail(context, properties);
            context.ExecuteQuery();
        }
        public User GetCurrentUser()
        {
            User currentUser = context.Web.CurrentUser;
            context.Load(currentUser);
            context.ExecuteQuery();
            return currentUser;
        }
    }
}
