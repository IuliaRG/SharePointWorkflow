using Accesa.ServiceDeskWeb;

using Accesa.ServiceDeskWeb.InternalDtos;
using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    
    public class DepartmentManagerService 
    { 
      
        public  void DistributeTicket(IEnumerable<string> keyPhrases, Ticket ticket)
        {
            string listTitle;
            ListItemFromServiceDeskService item = new ListItemFromServiceDeskService();
            IEnumerable<string> errors = new string[] { "error", "bug", "system", "system crash", "program crash", "program" };
            IEnumerable<string> results = errors.Where(i => keyPhrases.Contains(i));
            if (results.Count() > 0)
            {
                listTitle = "Development team";
                item.CreateListItem(ticket, listTitle);
            }
            else
            {
                listTitle = "Marketing team";
                item.CreateListItem(ticket, listTitle);
            }
        }
       
    }
}