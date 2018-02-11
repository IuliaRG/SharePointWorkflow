using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.WorkflowAgile
{
    public class MarketingWorkflow : Workflow
    {
        public string listTitle="Marketing team";
        public int listItemId;
        public MarketingWorkflow(int listItemId) : base()
        {
            context = SPClientContext.Instance.GetContext();
            this.listItemId = listItemId;
        }

        public override List<IAction> GetActions(string state)
        {
            List<IAction> actions = new List<IAction>();
            switch (state.ToString())
            {
                case "In progress":
                    actions.Add(new AssignToCurrentUserAction(listTitle, listItemId));
                    break;
                case "Solved":
                case "Responded to originator":
                    actions.Add(new SendMailWithTextFromOriginalTicketAction(listTitle, listItemId));
                    break;
            }

            return actions;
        }
    }
}