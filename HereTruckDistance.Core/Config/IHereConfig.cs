using System.Collections.Generic;

namespace HereTruckDistance.Core
{
    public interface IHereConfig
    {
        string AppCode { get; set; }
        string AppId { get; set; }
        IDictionary<string, string> UriServices { get; set; }
    }
}