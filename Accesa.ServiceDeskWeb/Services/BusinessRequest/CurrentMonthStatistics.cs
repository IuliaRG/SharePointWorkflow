using Accesa.ServiceDeskWeb.Controllers;
using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.InternalDtos;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Services.BusinessRequest
{
    public class CurrentMonthStatistics
    {
        public ListStatisticsStatus GetStatisticsOfStatus(string listTitle)
        {
            ListItemLoader listItemLoader = new ListItemLoader();
            var listItem = listItemLoader.GetAllListItem(listTitle, new List<string> { "Status", "Created" });
            DateTime validfrom;
            int itemsInProgress = 0;
            int itemsSolved = 0;
            int itemsNew = 0;
            for (int i = 0; i < listItem.Count; i++)
            {
                validfrom = (DateTime)listItem[i]["Created"];
                if (validfrom.Month == DateTime.Now.Month)
                {

                    if (listItem[i].FieldValues.Values.Contains("In progress"))
                    {
                        itemsInProgress++;
                    }
                    if (listItem[i].FieldValues.Values.Contains("Solved"))
                    {
                        itemsSolved++;
                    }
                    if (listItem[i].FieldValues.Values.Contains("New"))
                    {
                        itemsNew++;
                    }
                }
            }

            var status = new ListStatisticsStatus() { InProgress = itemsInProgress, New = itemsNew, Solved = itemsSolved };
            return status;
        }

        public int GetTotalNumberOfTicketReceivedInCurrentMonth(string listTitle)
        {
            ListItemLoader listItemLoader = new ListItemLoader();
            var listItem = listItemLoader.GetAllListItem(listTitle, new List<string> {"Created"});
            DateTime validfrom;
            int number = 0;
            for (int i = 0; i < listItem.Count; i++)
            {
                    validfrom = (DateTime)listItem[i]["Created"];
                    if (validfrom.Month == DateTime.Now.Month)
                    {
                        number++;
                    }
                
            }
            return number;
        }
       
    }
}