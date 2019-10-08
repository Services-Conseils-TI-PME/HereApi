using System;
using System.Collections.Generic;

namespace HereTruckDistance.Core
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