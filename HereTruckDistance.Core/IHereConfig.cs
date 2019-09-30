using System.Collections.Generic;

namespace HereTruckDistance.Core
{
    public interface IHereConfig
    {
        string HereAppCode { get; set; }
        string HereAppId { get; set; }
        string HereUri { get; set; }
        IDictionary<string, string> Services { get; set; }
    }
}