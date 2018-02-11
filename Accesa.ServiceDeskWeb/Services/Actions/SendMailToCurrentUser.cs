using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class SendMailToCurrentUser : SendEmailAction
    {
        private CurrentUserService currentUserService;
        private User currentUser;
        public override string Text { get { return "Your request was solved"; ; } }
        public override string EmailTo { get { return currentUser.Email; } }
        public SendMailToCurrentUser() : base()
        {
            currentUserService = new CurrentUserService();
            currentUser = currentUserService.GetCurrentUser();
        }
    }
}
