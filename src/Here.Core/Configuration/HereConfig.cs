using System;
using System.Collections.Generic;

namespace Here.Configuration
{
    public class HereConfig : IHereConfig
    {
        public string AppId { get; set; }
        public string AppCode { get; set; }
        public IDictionary<String, String> UriServices { get; set; }

        public HereConfig()
        {
        }
    }
}