using Here.Params;
using System.Collections.Generic;

namespace Here.Options
{
    public interface IHereOptions
    {
        IDictionary<string, IParamBase> Parametres { get; set; }

        string ToString();
    }
}