using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accesa.ServiceDeskWeb.Controllers;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.EventReceivers;

namespace Accesa.ServiceDeskWeb.Services
{
    public class NewServiceDeskRequest : IRemoteEventService
    {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            SPRemoteEventResult result = new SPRemoteEventResult();

            return result;
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
            var serviceDeskControler = new ServiceDeskController();
            serviceDeskControler.ProcessServiceDeskRequest(properties.ItemEventProperties.ListItemId);
        }
    }
}
