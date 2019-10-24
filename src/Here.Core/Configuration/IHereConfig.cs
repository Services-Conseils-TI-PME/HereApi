using System.Collections.Generic;

namespace Here.Configuration
{
    public interface IHereConfig
    {
        string AppCode { get; set; }
        string AppId { get; set; }
        IDictionary<string, string> UriServices { get; set; }
    }
}