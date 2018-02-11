using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class NumberOfListItem
    {
        public int GetNumberOfListItem(string listTitle)
        {
            ListItemLoader listItemLoader = new ListItemLoader();
            int number = listItemLoader.GetAllListItem(listTitle, new List<string> { "Status"}).Count;
            return number;

        }
    }
}