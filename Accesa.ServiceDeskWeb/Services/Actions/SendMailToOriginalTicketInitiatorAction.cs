using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class SendMailToOriginalTicketInitiatorAction : SendEmailAction
    {
        private ListItemIdentifiers listItemIdentifiers;
        private EmailFromOriginalTicket email;
        private string originalListTitile;
        public override string Text { get { return "Your request was solved"; } }
        public override string EmailTo { get { return email.GetEmailFromOriginalTicket(listItemIdentifiers.Id, originalListTitile); } }
        public SendMailToOriginalTicketInitiatorAction(string listTitle, string originalListTitile, int listItemId) : base()
        {
            listItemIdentifiers = new ListItemIdentifiers();
            listItemIdentifiers.Id = listItemId;
            this.originalListTitile = originalListTitile;
            email = new EmailFromOriginalTicket();
        }
    }
}