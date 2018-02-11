using Accesa.ServiceDeskWeb.Services;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{

    public class SPClientContext
    {
        private static SPClientContext instance;

        private ClientContext clientContext;
        private SPClientContext() {
            clientContext = SharePointContextProvider.GetContext();
        }

        public static SPClientContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SPClientContext();
                }
                return instance;
            }
        }

        public ClientContext GetContext()
        {
            return clientContext;
        }
    }
   
}
