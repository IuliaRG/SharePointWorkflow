using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class TicketOriginalText
    {
        private ClientContext context;

        public TicketOriginalText()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public string SendTextFromOriginalTicket(int id,string listTitle)
        { 
             ServiceDeskRequests serviceDeskItem = new ServiceDeskRequests();
            ListItemLoader listItemLoader = new ListItemLoader();
            ListItem listItem = listItemLoader.GetListItem(id, listTitle, new List<string> { "TicketID" });      
            int ticketID = ((FieldLookupValue)listItem["TicketID"]).LookupId;
            Ticket ticket = serviceDeskItem.GetTicket(ticketID);
            string textToSend = "Subject: " + ticket.Subject.ToString() + " " + "Original text: " + ticket.Body.ToString();
            return textToSend;
        }
    }
}