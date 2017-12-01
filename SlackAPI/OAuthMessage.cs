using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAPI
{
    public class OAuthMessage
    {
        public string client_id { get; set; }
        public string scope { get; set; }
        public string redirect_uri { get; set; }
        public string team { get; set; }
    }
}
