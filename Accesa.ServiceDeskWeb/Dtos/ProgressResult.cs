using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accesa.ServiceDeskWeb.Dtos
{
    public class ProgressResult
    {
        public string Title { get; set; }
        public string Error { get; set; }
        public string  Priority { get; set; }
        public string Request { get; set; }
    }
}