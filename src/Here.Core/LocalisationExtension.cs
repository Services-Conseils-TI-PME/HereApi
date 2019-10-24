using System.Globalization;

namespace Here
{
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