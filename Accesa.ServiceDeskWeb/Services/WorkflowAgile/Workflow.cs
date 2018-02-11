using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesa.ServiceDeskWeb.Services.WorkflowAgile
{
    public abstract class Workflow
    {
        public ClientContext context;
        public string state;
        public Workflow()
        {
            context = SPClientContext.Instance.GetContext();  
        }

        public void DoActions(string listTitle, int listItemId)
        {
            ListItemService item = new ListItemService();
            ListItem stateItem = item.GetListItem(listItemId, listTitle);
            state = stateItem["Status"].ToString();
            foreach (IAction action in GetActions(state))
            {
                action.Execute();
            }
        }
        public abstract List<IAction> GetActions(string state);   
    }
}
