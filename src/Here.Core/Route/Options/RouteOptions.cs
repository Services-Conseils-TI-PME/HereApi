using Here.Params;
using System.Collections.Generic;
using System.Linq;

namespace Here.Options.Route
{
    public class RouteOptions : IHereOptions
    {
        public RouteOptions()
        {
            Parametres = new Dictionary<string, IParamBase>();
        }

        public IDictionary<string, IParamBase> Parametres { get; set; }

        public override string ToString()
        {
            return string.Join("&", Parametres.Select(kv => kv.Value.ToString()).ToArray());
        }
    }
}