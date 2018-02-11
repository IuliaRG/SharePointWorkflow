using Accesa.ServiceDeskWeb.Dtos;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class ListItemLoader
    {
        protected ClientContext context;
        protected ListItem listItem;
        public ListItemLoader()
        {
            this.context = SPClientContext.Instance.GetContext();

        }

        public ListItem GetListItem(int id, string listTitle, List<string> fieldNames)
        {

            List teamList = context.Web.Lists.GetByTitle(listTitle);
            listItem = teamList.GetItemById(id);
            if (fieldNames != null)
            {
                foreach (var fieldName in fieldNames)
                    context.Load(listItem, item => item[fieldName]);
            }
            context.ExecuteQuery();

            return listItem;
        }

        public ListItemCollection GetAllListItem(string listTitle, List<string> fieldNames)
        {

            List teamList = context.Web.Lists.GetByTitle(listTitle);
            CamlQuery camlQuery = new CamlQuery();
            ListItemCollection collListItem = teamList.GetItems(camlQuery);

            if (fieldNames != null)
            {
                foreach (var fieldName in fieldNames)
                    context.Load(collListItem, items => items.Include(item => item[fieldName]));

            }
            context.ExecuteQuery();
            return collListItem;
        }

        public ListItemCollection GetSPListItems(string listTitle, string fieldName, string fieldValue, List<string> fieldNames)
        {
            List teamList = context.Web.Lists.GetByTitle(listTitle);
            CamlQuery camlQuery = new CamlQuery();

            camlQuery.ViewXml = "<View><Query><Where><Eq><FieldRef Name='" + fieldName + "' /><Value Type='Choice'>" + fieldValue + "</Value></Eq></Where></Query></View>";
            ListItemCollection collListItem = teamList.GetItems(camlQuery);

            if (fieldNames != null)
            {
                foreach (var field in fieldNames)
                    context.Load(collListItem, items => items.Include(item => item[field]));

            }
            context.ExecuteQuery();
            return collListItem;
        }
    }
}