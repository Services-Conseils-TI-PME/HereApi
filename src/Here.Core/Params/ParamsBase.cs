using System;

namespace Here.Params
{
    public class ParamsBase<T> : IParamBase //where T : notnull
    {
        public ParamsBase(string nom)
        {
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        }

        public ParamsBase(string nom, T valeur) : this(nom)
        {
            if (valeur == null)
                throw new ArgumentNullException(nameof(valeur));
            Valeur = valeur;
        }

        public T Valeur { get; set; }
        public string Nom { get; private set; }
        public virtual string ValeurStr => string.Format("{0}", Valeur);

        public override string ToString()
        {
            return string.Format("{0}={1}", Nom, ValeurStr);
        }
    }
}
