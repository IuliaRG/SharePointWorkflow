using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class SendMailWithTextFromOriginalTicketAction : SendEmailAction
    {
        private CurrentUserService currentUserService;
        private User currentUser;
        private TicketOriginalText textToSend;
        private ListItemIdentifiers listItemIdentifiers;
        public override string Text { get { return textToSend.SendTextFromOriginalTicket(listItemIdentifiers.Id, listItemIdentifiers.ListTitle); } }
        public override string EmailTo { get { return currentUser.Email; } }
        public SendMailWithTextFromOriginalTicketAction(string listTitle, int listItemId) : base()
        {
            listItemIdentifiers = new ListItemIdentifiers();
            listItemIdentifiers.Id = listItemId;
            listItemIdentifiers.ListTitle = listTitle;
            currentUserService = new CurrentUserService();
            textToSend = new TicketOriginalText();
            currentUser = currentUserService.GetCurrentUser();
        }
    }
}
