using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesa.ServiceDeskWeb
{
    public class ResponseSentiment
    {
        public List<DocumentSentiment> documents { get; set; }
        public List<object> errors { get; set; }
    }
}
