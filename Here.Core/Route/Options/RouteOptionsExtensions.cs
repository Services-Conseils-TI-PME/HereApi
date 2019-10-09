using Here.Params;
using System;
using System.Collections.Generic;

namespace Here.Options.Route
{
    public static class RouteOptionsExtensions
    {
        public static void AddRange(this IHereOptions target, IHereOptions source)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (var element in source.Parametres)
                target.Parametres.TryAdd(element.Key, element.Value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur"></param>
        /// <param name="index">Départ --> 0, Arrivé --> 1</param>
        public static void AddLocalisation(this RouteOptions tpParams, Localisation valeur, int index)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (string.IsNullOrEmpty(valeur.GetPointString())) throw new ArgumentException(nameof(valeur));
            if (index < 0 || index > 1) throw new ArgumentException(nameof(index));

            string nom = "waypoint" + index.ToString();
            var param = new ParamsBase<Localisation>(nom, valeur);

            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        public static void AddMode(this RouteOptions tpParams, Mode[] valeurs)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeurs == null || valeurs.Length <= 0) throw new ArgumentNullException(nameof(valeurs));

            string nom = "mode";
            var param = new ParamsArray<Mode>(nom, valeurs);

            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }
    }
}