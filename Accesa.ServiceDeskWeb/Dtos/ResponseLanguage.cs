using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesa.ServiceDeskWeb
{
    public class ResponseLanguage
    {
        public List<DocumentLanguage> documents { get; set; }
        public List<object> errors { get; set; }
    }
}
