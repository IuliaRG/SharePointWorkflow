using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;

using Accesa.ServiceDeskWeb.Services;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Accesa.ServiceDeskWeb.Services.Actions;

namespace Accesa.ServiceDeskWeb.Controllers
{
    public class ServiceDeskController : ApiController
    {
        [HttpPost]
        public void ProcessServiceDeskRequest(int id)
        {
            ServiceDeskRequests serviceDeskItem = new ServiceDeskRequests();
            DepartmentManagerService manageTicket = new DepartmentManagerService();
            Ticket ticket = serviceDeskItem.GetTicket(id);
            IEnumerable<string> listKeyPhrases = new TextAnalyticsService().GetKeyPhrases(ticket.Body);
            manageTicket.DistributeTicket(listKeyPhrases, ticket);
        }        
    }
}




