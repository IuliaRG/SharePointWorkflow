using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class EmailFromOriginalTicket
    {
        private ClientContext context;

        public EmailFromOriginalTicket()
        {
            this.context = SPClientContext.Instance.GetContext();
        }

        public string GetEmailFromOriginalTicket(int id,string listTitle)
        {
            ListItemLoader listItemLoader = new ListItemLoader();
            ListItem listItem=listItemLoader.GetListItem(id, listTitle, new List<string> { "From"});
            string resultFrom = listItem["From"].ToString();
            if (listItem["From"] != null)
            {
                FieldUserValue user = (FieldUserValue)listItem["From"];
                resultFrom = user.Email;
            }

            return resultFrom;
        }
    }
}