using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Accesa.ServiceDeskWeb.Services;
using Microsoft.SharePoint.Client;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
//using Accesa.DevelopmentTeamkWeb.Services;

namespace Accesa.ServiceDeskWeb.Controllers
{
    public class ProvisioningController : ApiController
    {
        [HttpGet]
        public void ProvisionSiteCollection()
        {
            ProvisionNewServiceDeskRequestList();
            AddTeamServiceDeskEventReceiver();
        }

        void AddTeamServiceDeskEventReceiver()
        {
            AddEventRecieverToWorkflow("Development team");
            AddEventRecieverToWorkflow("Marketing team");
        }

        public void AddEventRecieverToWorkflow(string listName)
        {
            var context = SPClientContext.Instance.GetContext();
            Web site = context.Web;
            List serviceMarketingList = site.Lists.GetByTitle(listName);
            context.Load(serviceMarketingList.EventReceivers);
            context.ExecuteQuery();
            bool eventAlreadyExists = serviceMarketingList.EventReceivers.Any(eventReceiver => eventReceiver.ReceiverName.Equals("Workflow Updated"));
            if (!eventAlreadyExists)
            {
                EventReceiverDefinitionCreationInformation eventReceiverInfo = new EventReceiverDefinitionCreationInformation();
                eventReceiverInfo.EventType = EventReceiverType.ItemUpdated;
                eventReceiverInfo.ReceiverClass = typeof(WorkflowService).FullName;
                eventReceiverInfo.ReceiverName = "Workflow Updated";
                eventReceiverInfo.ReceiverUrl = $"{ConfigurationManager.AppSettings["RemoteWebUrl"]}/Services/WorkflowService.svc";
                eventReceiverInfo.SequenceNumber = 1001;
                eventReceiverInfo.ReceiverAssembly = Assembly.GetExecutingAssembly().FullName;
                serviceMarketingList.EventReceivers.Add(eventReceiverInfo);
                serviceMarketingList.Update();
                context.ExecuteQuery();
            }
        }

        private void ProvisionNewServiceDeskRequestList()
        {
            using (var ctx = SPClientContext.Instance.GetContext())
            {
                Web site = ctx.Web;
                List targetList = site.Lists.GetByTitle("ServiceDesk Requests");
                try
                {
                    ctx.Load(targetList);
                    ctx.ExecuteQuery();
                }
                catch (Exception ex)
                {
                    ListCreationInformation listCreationInfo = new ListCreationInformation();
                    listCreationInfo.Title = "ServiceDesk Requests";
                    listCreationInfo.TemplateType = (int)ListTemplateType.GenericList;
                    List oList = site.Lists.Add(listCreationInfo);
                    ctx.ExecuteQuery();
                    oList.Fields.AddFieldAsXml("<Field DisplayName='Subject' Type='Text' />", true, AddFieldOptions.AddFieldToDefaultView);
                    oList.Fields.AddFieldAsXml("<Field DisplayName='Body' Type='Note' />", true, AddFieldOptions.AddFieldToDefaultView);
                    oList.Fields.AddFieldAsXml("<Field DisplayName='From' Type='User' List='UserInfo' />", true, AddFieldOptions.AddFieldToDefaultView);
                    ctx.ExecuteQuery();
                    var eventRecievers = oList.EventReceivers;
                    ctx.Load(eventRecievers);
                    ctx.ExecuteQuery();
                    EventReceiverDefinitionCreationInformation eventReceiverInfo = new EventReceiverDefinitionCreationInformation();
                    eventReceiverInfo.EventType = EventReceiverType.ItemAdded;
                    eventReceiverInfo.ReceiverClass = typeof(NewServiceDeskRequest).FullName;
                    eventReceiverInfo.ReceiverName = "NewServiceDeskRequest Created";
                    eventReceiverInfo.ReceiverUrl = $"{ConfigurationManager.AppSettings["RemoteWebUrl"]}/Services/NewServiceDeskRequest.svc";
                    eventReceiverInfo.SequenceNumber = 1001;
                    eventReceiverInfo.ReceiverAssembly = Assembly.GetExecutingAssembly().FullName;
                    oList.EventReceivers.Add(eventReceiverInfo);
                    oList.Update();
                    ctx.ExecuteQuery();
                }
            }
        }
    }
}