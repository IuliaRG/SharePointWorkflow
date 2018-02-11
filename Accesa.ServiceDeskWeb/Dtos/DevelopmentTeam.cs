using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Class
{
    public class DevelopmentTeam
    {
        public List<string> Title { get; set; }
        public string TicketID  { get; set; }
        public string Error { get; set; }
        public string Priority { get; set; }
        public string Body { get; set; }
    }
}