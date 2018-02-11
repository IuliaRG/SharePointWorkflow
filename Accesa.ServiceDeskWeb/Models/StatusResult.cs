using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Models
{
    public class StatusResult
    {
        public int StatusNew { get; set; }
        public int StatusInProgress { get; set; }
        public int StatusSolved { get; set; }
    }
}