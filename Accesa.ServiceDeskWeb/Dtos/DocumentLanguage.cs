using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesa.ServiceDeskWeb
{
           public class DocumentLanguage
    {
             public string id { get; set; }
        public List<DetectedLanguage> detectedLanguages { get; set; }
    }
}
