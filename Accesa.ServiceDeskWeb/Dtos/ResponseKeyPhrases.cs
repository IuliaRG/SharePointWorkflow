using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesa.ServiceDeskWeb
{
    public class ResponseKeyPhrases
    {
        public List<DocumentKeyPhrases> documents { get; set; }
        public List<object> errors { get; set; }
    }

    public class KeyPhrasesResult {
        public IEnumerable<string> KeyPhrases { get; set; }
        public List<object> errors { get; set; }

    }
}
