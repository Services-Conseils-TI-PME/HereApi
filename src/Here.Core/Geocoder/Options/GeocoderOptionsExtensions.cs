using Here.Models;
using Here.Params;
using System;
using System.Collections.Generic;

namespace Here.Options.Geocoder
{
    public static class GeocoderOptionsExtensions
    {
        private static void AddParam<T>(this GeocoderOptions tpParams, string nom, ParamsBase<T> param)
        {
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        public static void AddAdresse(this GeocoderOptions tpParams, AdresseModel valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur == null) throw new ArgumentNullException(nameof(valeur));

            if (valeur.NoCivique > 0)
            {
                string nom = "housenumber";
                tpParams.AddParam<int>(nom, new ParamsBase<int>(nom, valeur.NoCivique));
            }
            if (!string.IsNullOrEmpty(valeur.Rue))
            {
                string nom = "street";
                tpParams.AddParam<string>(nom, new ParamsBase<string>(nom, valeur.Rue));
            }
            if (!string.IsNullOrEmpty(valeur.Ville))
            {
                string nom = "city";
                tpParams.AddParam<string>(nom, new ParamsBase<string>(nom, valeur.Ville));
            }
            if (!string.IsNullOrEmpty(valeur.Pays))
            {
                string nom = "country";
                tpParams.AddParam<string>(nom, new ParamsBase<string>(nom, valeur.Pays));
            }
        }
    }
}