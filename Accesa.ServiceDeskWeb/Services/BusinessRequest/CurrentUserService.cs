using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class CurrentUserService
    {
        private ClientContext context;

        public CurrentUserService()
        {
            this.context = SPClientContext.Instance.GetContext();
        }

        public User GetCurrentUser()
        {
            User user = new SharePointArhitecture().GetCurrentUser();
            return user;
        }
    }
}