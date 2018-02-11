using Accesa.ServiceDeskWeb.InternalDtos;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class PriorityService
    {
        private ClientContext context;

        public PriorityService()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public void ChangePriority(int id,string ListTitle)
        {
            TeamTicket ticket =new  TeamTicket();
            ListItem teamListItem = ticket.GetTicket(id, ListTitle);
            DateTime validfrom = (DateTime)teamListItem["Created"];
            DateTime validTo = DateTime.Today;
            int result = validTo.Subtract(validfrom).Days;
            if (!teamListItem["Status"].ToString().Equals("Solved") && !teamListItem["Status"].ToString().Equals("In progress") && result > 2)
            {
                teamListItem["Priority"] = Priority.High;
                teamListItem.Update();
                context.ExecuteQuery();
            }
        }
    }
}