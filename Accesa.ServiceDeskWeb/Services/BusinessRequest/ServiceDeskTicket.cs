using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ServiceDeskTicket :TicketContext
    {
        public override ListItem GetTicketProperties(ListItem listitem,string listTitle)
        {
            context.Load(listitem, item => item["Title"], item => item["Subject"], item => item["Body"], item => item["From"]);
            context.ExecuteQuery();

            return listitem;

        }
    }
}