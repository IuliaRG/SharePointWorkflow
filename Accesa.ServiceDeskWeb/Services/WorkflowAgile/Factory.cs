using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.InternalDtos;
using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Accesa.ServiceDeskWeb.Services.WorkflowAgile
{
    public class Factory
    {
        public ClientContext context;
        public Factory()
        {
            this.context = SPClientContext.Instance.GetContext();
        }

        public Workflow CreateWorkflows(string listTitle,int listItemId)
        {
            Workflow entity =null;
            switch (listTitle)
            {
                case "Development team":
                   entity = new DevWorkflow(listItemId);
                    break;

                case "Marketing team":
                    entity = new MarketingWorkflow(listItemId);
                    break;
            }

            return entity;
        }
    }
}
