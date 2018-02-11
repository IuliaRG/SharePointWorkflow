using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.InternalDtos;
using Accesa.ServiceDeskWeb.Services.Actions;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.Actions
{
    public class SetUserFieldAction : IAction
    {
        public ClientContext context;
        public ListItemIdentifiers ListItemIdentifiers;
        public virtual string FieldName { get; set; }
        public virtual User User { get; set; }
        public SetUserFieldAction()
        {
            context = SPClientContext.Instance.GetContext();
        }
        public void Execute()
        {
            List teamList = context.Web.Lists.GetByTitle(ListItemIdentifiers.ListTitle);
            var listItem = teamList.GetItemById(ListItemIdentifiers.Id);
            listItem[FieldName] = User;
            listItem.Update();
            context.ExecuteQuery();
        }
    }
}