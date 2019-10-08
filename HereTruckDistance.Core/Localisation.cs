using System.Globalization;

namespace HereTruckDistance.Core
{
    public class Localisation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Localisation(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public static class LocalisationExtension
    {
        public static string GetPointString(this Localisation localisation)
        {
            return string.Format("{0},{1}",
                localisation.Latitude.ToString(CultureInfo.InvariantCulture),
                localisation.Longitude.ToString(CultureInfo.InvariantCulture));
        }
    }
}