using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.InternalDtos;
using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.WorkflowAgile
{
    public class DevWorkflow : Workflow
    {
        public const string listTitle="Development team";
        public const string originallistTitle = "ServiceDesk Requests";
        public int listItemId;
        public DevWorkflow(int listItemId) : base()
        {
            context = SPClientContext.Instance.GetContext();
            this.listItemId = listItemId;
        }

        public override List<IAction> GetActions(string state)
        {
            List<IAction> actions = new List<IAction>();
            switch (state)
            {
                case "In progress":
                    actions.Add(new AssignToCurrentUserAction(listTitle, listItemId));
                    break;
                case "Solved":
                case "No Repro":
                case "Known issue":
                    actions.Add(new SendMailToOriginalTicketInitiatorAction(listTitle,originallistTitle, listItemId));
                    break;
            }

            return actions;
        }
    }
}
