using System;
using System.Collections.Generic;

namespace HereTruckDistance.Core
{
    public class HereConfig : IHereConfig
    {
        public string HereUri { get; set; }
        public string HereAppId { get; set; }
        public string HereAppCode { get; set; }
        public IDictionary<String, String> Services { get; set; }

        public HereConfig()
        {
        }
    }

}