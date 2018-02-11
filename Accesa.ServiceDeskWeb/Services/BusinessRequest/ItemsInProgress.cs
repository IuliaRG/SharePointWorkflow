using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ItemsInProgress 
    {
        public int GetNumberOfTicketInProgressPriorityHigh(string listTitle)
        {
            int ok = 0;
            ListItemLoader listItemLoader = new ListItemLoader();
            var listItem = listItemLoader.GetAllListItem(listTitle, new List<string> { "Status","Priority" });
            for (int i = 0; i < listItem.Count; i++)
            {
                if (listItem[i].FieldValues.Values.Contains("In progress") && listItem[i].FieldValues.Values.Contains("High"))
                    ok++;
            }
             return ok;
        }

        public int GetNumberOfTicketInProgress(string listTitle)
        {
            int ok = 0;
            ListItemLoader listItemLoader = new ListItemLoader();
            var listItem = listItemLoader.GetAllListItem(listTitle, new List<string> { "Status" });
            for (int i = 0; i < listItem.Count; i++)
            {
                if (listItem[i].FieldValues.Values.Contains("In progress"))
                    ok++;
            }
            return ok;
        }
    }
}