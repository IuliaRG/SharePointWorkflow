using Accesa.ServiceDeskWeb.InternalDtos;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ListItemFromServiceDeskService
    {
        public void CreateListItem(Ticket ticket, string listTitle)
        {
            var context = SPClientContext.Instance.GetContext();
            Web site = context.Web;
            List serviceTeam = site.Lists.GetByTitle(listTitle);
            ListItemCreationInformation listItemInfo = new ListItemCreationInformation();
            ListItem teamListItem = serviceTeam.AddItem(listItemInfo);
            teamListItem["TicketID"] = ticket.Id;
            switch (listTitle)
            {
                case "Development team":
                    teamListItem["Error"] = ticket.Body;
                    break;
                case "Marketing team":
                    teamListItem["Error"] = ticket.Body;
                    break;
            }
            teamListItem["Status"] = AllStatus.New;
            teamListItem["Priority"] = Priority.Low;
            teamListItem.Update();
            context.ExecuteQuery();
        }
    }
}