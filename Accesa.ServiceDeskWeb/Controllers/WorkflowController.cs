using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Accesa.ServiceDeskWeb.Services.WorkflowAgile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Accesa.ServiceDeskWeb.Controllers
{
    public class WorkflowController : ApiController
    {
        [HttpPost]
        public void ProcessWorkflowActions(string listTitle, int listItemId)
        {
            Workflow workflow;
            Factory factory = new Factory();
            workflow = factory.CreateWorkflows(listTitle, listItemId);
            workflow.DoActions(listTitle, listItemId);
        }
    }
}