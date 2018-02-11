using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public abstract class TicketContext
    {
        protected ClientContext context;
        protected ListItem listItem;
        public TicketContext()
        {
            this.context = SPClientContext.Instance.GetContext();
       
        }
        public ListItem GetTicket(int id, string listTitle)
        {
            List teamList = context.Web.Lists.GetByTitle(listTitle);
            listItem = teamList.GetItemById(id);
            ListItem ticket = GetTicketProperties(listItem, listTitle);
            return ticket;
        }

        public abstract ListItem GetTicketProperties(ListItem listItem, string listTitle );
    }
}