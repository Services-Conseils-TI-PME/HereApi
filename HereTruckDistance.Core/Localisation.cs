using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HereTruckDistance.Core
{
    public class Localisation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string Point { get { return string.Format("{0},{1}", Latitude.ToString(CultureInfo.InvariantCulture), Longitude.ToString(CultureInfo.InvariantCulture)); }}

        public Localisation(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
