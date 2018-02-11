using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class AssignToCurrentUserAction : SetUserFieldAction
    {
        private CurrentUserService currentUserService;
        public override string FieldName { get { return "Assigned"; } }
        public override User User { get { return currentUserService.GetCurrentUser(); } }
        public AssignToCurrentUserAction(string listTitle, int listItemId) : base()
        {
            currentUserService = new CurrentUserService();
            ListItemIdentifiers = new ListItemIdentifiers();
            ListItemIdentifiers.Id = listItemId;
            ListItemIdentifiers.ListTitle = listTitle;
        }
    }
}