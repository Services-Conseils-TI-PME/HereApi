using System.Collections.Generic;
using System.Linq;

namespace HereTruckDistance.Core
{
    public class TruckProfileParams
    {
        public Dictionary<string, IParamBase> Parametres { get; set; }

        public override string ToString()
        {
            return string.Join(" ", Parametres.Select(kv => kv.ToString()).ToArray());
        }
    }
}