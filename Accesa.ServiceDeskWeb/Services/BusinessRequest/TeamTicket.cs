using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class TeamTicket : TicketContext
    {
        public override ListItem GetTicketProperties(ListItem listitem,string listTitle)
        {
            context.Load(listitem, item => item["TicketID"], item => item["Status"], item => item["Assigned"], item => item["Created"], item => item["Priority"]);
            switch (listTitle)
            {
                case "Development team":
                    context.Load(listitem, item => item["Error"]);
                    break;
                case "Marketing team":
                    context.Load(listitem, item => item["Request"]);
                    break;
            }
            context.ExecuteQuery();
            return listitem;

        }
    }
}