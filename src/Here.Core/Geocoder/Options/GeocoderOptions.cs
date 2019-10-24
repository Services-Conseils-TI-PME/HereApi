using Here.Params;
using System.Collections.Generic;
using System.Linq;

namespace Here.Options.Geocoder
{
    public class GeocoderOptions : IHereOptions
    {
        public GeocoderOptions()
        {
            Parametres = new Dictionary<string, IParamBase>();
        }

        public IDictionary<string, IParamBase> Parametres { get; set; }

        public override string ToString()
        {
            return string.Join("&", Parametres.Select(kv => kv.Value.ToString()).ToArray());
        }

        public void Initialiser()
        {
            Parametres.Clear();
        }
    }
}