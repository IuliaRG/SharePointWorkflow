using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Dtos
{
    public class ListStatisticsStatus
    {
        public int InProgress { get; set; }
        public int Solved { get; set; }
        public int New { get; set; }

    }
}