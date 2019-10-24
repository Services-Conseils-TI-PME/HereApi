using Here.Params;
using System;
using System.Collections.Generic;

namespace Here.Options.Route
{
    public static class RouteTruckOptionsExtensions
    {
        private const string ErrorMsgValueBetween = "La valeur doit être entre {0} et {1}";

        /// <summary>
        /// Truck routing only, specifies the vehicle type.Defaults to truck.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">Enum [truck | tractorTruck]</param>
        public static void AddTruckType(this RouteTruckOptions tpParams, TruckType valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            string nom = "truckType";
            var param = new ParamsEnum<TruckType>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, specifies number of trailers pulled by the vehicle.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 4. Defaults to 0.</param>
        public static void AddTrailersCount(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 4) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 4), nameof(valeur));
            string nom = "trailerCount";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, specifies number of axles on the vehicle.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 2 and 254. Defaults to 2.</param>
        public static void AddAxleCount(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 2 && valeur > 254) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 2, 254), nameof(valeur));

            string nom = "axleCount";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, list of hazardous materials in the vehicle. Please refer to the enumeration type HazardousGoodTypeType for available values.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">Enum [explosive | gas | flammable | combustible | organic | poison | radioActive | corrosive | poisonousInhalation | harmfulToWater | other]</param>
        public static void AddShippedHazardousGoods(this RouteTruckOptions tpParams, ShippedHazardousGoods valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            string nom = "shippedHazardousGoods";
            var param = new ParamsEnum<ShippedHazardousGoods>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, vehicle weight including trailers and shipped goods, in tons.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 1000.</param>
        public static void AddLimitedWeight(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 1000) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 1000), nameof(valeur));

            string nom = "limitedWeight";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, vehicle weight per axle in tons.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 1000.</param>
        public static void AddWeightPerAxle(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 1000) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 1000), nameof(valeur));

            string nom = "weightPerAxle";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        //TODO: weightsPerAxleGroup

        /// <summary>
        /// Truck routing only, vehicle height in meters.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 50.</param>
        public static void AddHeight(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 50) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 50), nameof(valeur));

            string nom = "height";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, vehicle width in meters.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 50.</param>
        public static void AddWidth(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 50) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 50), nameof(valeur));

            string nom = "width";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, vehicle length in meters.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">The provided value must be between 0 and 300.</param>
        public static void AddLength(this RouteTruckOptions tpParams, int valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            if (valeur < 0 && valeur > 300) throw new ArgumentException(string.Format(ErrorMsgValueBetween, 0, 300), nameof(valeur));

            string nom = "length";
            var param = new ParamsBase<int>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, specifies the tunnel category to restrict certain route links. The route will pass only through tunnels of a less strict category.
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">Enum [ B | C | D | E ]</param>
        public static void AddTunnelCategory(this RouteTruckOptions tpParams, TunnelCategory valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            string nom = "tunnelCategory";
            var param = new ParamsEnum<TunnelCategory>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }

        /// <summary>
        /// Truck routing only, specifies the penalty type on violated truck restrictions.
        /// Defaults to strict.
        /// Refer to the enumeration type TruckRestrictionPenaltyType for details on available values.
        /// Note that the route computed with the penalty type soft will use links with a violated truck restriction if there is no alternative to avoid them.
        /// The route violating truck restrictions is then indicated with dedicated route and maneuver notes in the response
        /// </summary>
        /// <param name="tpParams"></param>
        /// <param name="valeur">Enum [ strict | soft ]</param>
        public static void AddTruckRestrictionPenalty(this RouteTruckOptions tpParams, TruckRestrictionPenalty valeur)
        {
            if (tpParams == null) throw new ArgumentNullException(nameof(tpParams));
            string nom = "truckRestrictionPenalty";
            var param = new ParamsEnum<TruckRestrictionPenalty>(nom, valeur);
            if (!tpParams.Parametres.TryAdd(nom, param))
            {
                tpParams.Parametres.Remove(nom);
                tpParams.Parametres.Add(nom, param);
            }
        }
    }
}