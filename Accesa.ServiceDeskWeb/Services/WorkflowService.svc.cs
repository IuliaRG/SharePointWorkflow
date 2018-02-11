using Accesa.ServiceDeskWeb.Controllers;
using Accesa.ServiceDeskWeb.Services.WorkflowAgile;
using Microsoft.SharePoint.Client.EventReceivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Accesa.ServiceDeskWeb.Services
{
    public class WorkflowService : IRemoteEventService
    {
        public SPRemoteEventResult ProcessEvent(SPRemoteEventProperties properties)
        {
            SPRemoteEventResult result = new SPRemoteEventResult();

            return result;
        }

        public void ProcessOneWayEvent(SPRemoteEventProperties properties)
        {
            var factoryDecision = new WorkflowController();
            factoryDecision.ProcessWorkflowActions(properties.ItemEventProperties.ListTitle, properties.ItemEventProperties.ListItemId);
        }


    }
}

