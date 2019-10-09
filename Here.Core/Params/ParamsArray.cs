using System;
using System.Linq;

namespace Here.Params
{
    public class ParamsArray<T> : IParamBase
    {
        public ParamsArray(string nom)
        {
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        }

        public ParamsArray(string nom, T[] valeurs) : this(nom)
        {
            if (valeurs == null)
                throw new ArgumentNullException(nameof(valeurs));
            Valeurs = valeurs;
        }

        public string Nom { get; set; }

        public T[] Valeurs { get; set; }

        public string ValeurStr
        {
            get
            {
                return string.Join(" ", Valeurs.Select(v => v.ToString()).ToArray());
            }
        }
    }
}