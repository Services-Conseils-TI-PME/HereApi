using System;

namespace HereTruckDistance.Core
{
    public class ParamsBase<T> : IParamBase where T : notnull
    {
        public ParamsBase(string nom)
        {
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        }

        public ParamsBase(string nom, T valeur) : this(nom)
        {
            Valeur = valeur ?? throw new ArgumentNullException(nameof(valeur));
        }

        public T Valeur { get; set; }
        public string Nom { get; private set; }
        public string ValeurStr { get { return string.Format("{0}", Valeur); } }

        public override string ToString()
        {
            ; return string.Format("{0} = {1}", Nom, ValeurStr);
        }
    }
}