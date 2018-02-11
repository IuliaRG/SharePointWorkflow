using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ListItemService
    {
        private ClientContext context;

        public ListItemService()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public  ListItem GetListItem(int id, string listTitle)
        {
            Web site = context.Web;
            List teamList = site.Lists.GetByTitle(listTitle);
            ListItem teamItem = teamList.GetItemById(id);
            context.Load(teamItem, item => item["TicketID"], item => item["Status"], item => item["Assigned"], item => item["Created"], item => item["Priority"]);
            context.ExecuteQuery();

            return teamItem;
        }
    }
}