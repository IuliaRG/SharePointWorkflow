using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class SendEmailAction :IAction
    {
        private ClientContext context;
        public virtual string EmailTo { get; set; }
        public virtual string Text { get; set; }
        public SendEmailAction()
        {
            this.context = SPClientContext.Instance.GetContext();
        }
        public void Execute()
        {
            EmailProperties properties = new EmailProperties();
            properties.To = new string[] { EmailTo };
            properties.Body = Text;
            Utility.SendEmail(context, properties);
            context.ExecuteQuery(); 
        }
    }
}