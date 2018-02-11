using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
    }
}