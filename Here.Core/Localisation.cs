using System.Globalization;

namespace Here
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

        public override string ToString()
        {
            return this.GetPointString();
        }
    }
}
