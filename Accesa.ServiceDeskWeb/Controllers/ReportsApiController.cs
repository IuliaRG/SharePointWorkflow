using Accesa.ServiceDeskWeb.Class;
using Accesa.ServiceDeskWeb.Dtos;
using Accesa.ServiceDeskWeb.Models;
using Accesa.ServiceDeskWeb.Services.BusinessRequest;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Accesa.ServiceDeskWeb.Controllers
{
    public class ReportsApiController : ApiController
    {
        [HttpGet]
        public ListStatisticsStatus GetDataStatus(string listTitle, int? month=null)
        {
            NumberOfItems itemsInProgress = GetItemCount(listTitle, month, "In Progress");
            NumberOfItems itemsSolved = GetItemCount(listTitle, month, "Solved");
            NumberOfItems itemsNew = GetItemCount(listTitle, month, "New");
            ListStatisticsStatus result;
            if (month != null)
            {
                 result = new ListStatisticsStatus() { InProgress = itemsInProgress.NumberWithSpecificProperty, New = itemsNew.NumberWithSpecificProperty, Solved = itemsSolved.NumberWithSpecificProperty };
            }
            else
            {
               result = new ListStatisticsStatus() { InProgress = itemsInProgress.TotalNumber, New = itemsNew.TotalNumber, Solved = itemsSolved.TotalNumber };
            }
            return result;
        }

        [HttpGet]
        public ListStatisticsPriority GetDataPriority(string listTitle)
        {
            ListItemLoader item = new ListItemLoader();
            int priorityLow = 0;
            int priorityMid = 0;
            int priorityHigh = 0;
            var resultPriority = item.GetAllListItem(listTitle, new List<string> { "Priority" });
            for (int i = 0; i < resultPriority.Count; i++)
            {
                if (resultPriority[i].FieldValues.Values.Contains("Low"))
                {
                    priorityLow++;
                }
                if (resultPriority[i].FieldValues.Values.Contains("Mid"))
                {
                    priorityMid++;
                }
                if (resultPriority[i].FieldValues.Values.Contains("High"))
                {
                    priorityHigh++;
                }
            }
            var status = new ListStatisticsPriority() { Low = priorityLow, Mid = priorityMid, High = priorityHigh };
            return status;
        }

        [HttpGet]
        public NumberOfItems GetDataInProgressWithHighPriority(string listTitle)
        {
            ItemsInProgress item = new ItemsInProgress();
            var numberWithProrityHigh = item.GetNumberOfTicketInProgressPriorityHigh(listTitle);
            var totalNumberOfTickets = item.GetNumberOfTicketInProgress(listTitle);
            var numberOfTickets = new NumberOfItems() { TotalNumber = totalNumberOfTickets, NumberWithSpecificProperty = numberWithProrityHigh };
            return numberOfTickets;
        }

        [HttpGet]
        public ListStatisticsStatus GetStatisticsOfStatusCurrentMonth(string listTitle)
        {
            int data = DateTime.Now.Month;
            ListStatisticsStatus result = GetDataStatus(listTitle, data);
            return result;
        }

        [HttpGet]
        public List<ProgressResult> GetData(string listTitle, string state)
        {
            ListItemLoader item = new ListItemLoader();
            ListItemCollection result = null;
            switch (listTitle)
            {
                case "Development team":
                    result = item.GetSPListItems(listTitle, "Status", state, new List<string> { "Title", "Priority", "Error" });
                    return ProcessDevelopmentData(result);
                case "Marketing team":
                    result = item.GetSPListItems(listTitle, "Status", state, new List<string> { "Title", "Priority", "Request" });
                    return ProcessMarketingData(result);
            }
            return null;
        }

        private List<ProgressResult> ProcessDevelopmentData(ListItemCollection data)
        {
            List<ProgressResult> result = new List<ProgressResult>();

            if (data != null)
            {
                result = data.Select(s => new ProgressResult() { Title = ((string)s.FieldValues["Title"]), Priority = ((string)s.FieldValues["Priority"]), Error = ((string)s.FieldValues["Error"]) }).ToList();
            }
            return result;
        }

        private List<ProgressResult> ProcessMarketingData(ListItemCollection data)
        {
            List<ProgressResult> result = new List<ProgressResult>();
            if (data != null)
            {
                result = data.Select(s => new ProgressResult() { Title = ((string)s.FieldValues["Title"]), Priority = ((string)s.FieldValues["Priority"]), Request = ((string)s.FieldValues["Request"]) }).ToList();
            }
            return result;
        }

        private NumberOfItems GetItemCount(string listTitle, int? month, string status)
        {
            ListItemLoader listItemLoader = new ListItemLoader();
            var listItems = listItemLoader.GetSPListItems(listTitle, "Status", status, new List<string> { "Status", "Created" });
            return CountListItems(listItems, month);
        }

        private NumberOfItems CountListItems(ListItemCollection listItems, int? month)
        {
            int itemsCount = 0;
            int monthItemsCount = 0;

            for (var i = 0; i < listItems.Count; i++)
            {
                if (month != null)
                {
                    DateTime validfrom = (DateTime)listItems[i]["Created"];
                    if (validfrom.Month == month.Value)
                        monthItemsCount++;
                }
                itemsCount++;
            }
            var result = new NumberOfItems() { NumberWithSpecificProperty = monthItemsCount, TotalNumber = itemsCount };
            return result;
        }
    }
}
