using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraceViewer.Data
{
    public class Token
    {
        public bool autenticated { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
    }
}
