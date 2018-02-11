using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ServiceDeskRequests
    {
        private ClientContext context;

        public ServiceDeskRequests()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public Ticket GetTicket(int id)
        {
            string ticketSubject = null, ticketBody = null;
            ListItem serviceDeskItem = GetServiceDeskListItem(id);
            string ticketId = id.ToString();
            string ticketTitle = serviceDeskItem["Title"].ToString();
            if (serviceDeskItem["Subject"] != null)
            {
                ticketSubject = serviceDeskItem["Subject"].ToString();
            }
            if (serviceDeskItem["Body"] != null)
            {
                ticketBody = serviceDeskItem["Body"].ToString();
            }
            Ticket ticket = new Ticket();
            ticket.Id = ticketId;
            ticket.Title = ticketTitle;
            ticket.Subject = ticketSubject;
            ticket.Body = ticketBody;

            return ticket;
        }
        public  ListItem GetServiceDeskListItem(int id)
        {
          
            Web site = context.Web;
            List serviceDeskList = site.Lists.GetByTitle("ServiceDesk Requests");
            Microsoft.SharePoint.Client.ListItem serviceDeskItem = serviceDeskList.GetItemById(id);
            context.Load(serviceDeskItem, item => item["Title"], item => item["Subject"], item => item["Body"], item => item["From"]);
            context.ExecuteQuery();
         
            return serviceDeskItem;
        }
    }
}