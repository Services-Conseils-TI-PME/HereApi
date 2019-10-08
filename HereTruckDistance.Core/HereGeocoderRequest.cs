using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HereTruckDistance.Core
{
    public class HereGeocoderRequest : HereRequest
    {
        public Localisation PointDepart { get; set; }
        public Localisation PointDestination { get; set; }
        public IList<string> Mode { get; set; }
        public bool Trafic { get; set; }
        public decimal LimitePoids { get; set; }
        public decimal Height { get; set; }
        public string ShippedHazardousGoods { get; set; }

        public HereGeocoderRequest(IConfiguration config) : base(config, "GeocoderSvc")
        {
            PointDepart = new Localisation(52.5m, 13.4m);
            PointDestination = new Localisation(52.5m, 13.45m);
            Mode = new List<string> { "fastest", "truck", "traffic:disabled" };
            LimitePoids = 30.5m;
            Height = 30.5m;
            ShippedHazardousGoods = "harmfulToWater";
        }

        public Uri GetRequest()
        {
            //TODO: À changer pour un string builder
            UriBuilder uri = new UriBuilder(ServiceUri);
            uri.Query = string.Format("app_id={0}&app_code={1}" +
                "&housenumber={2}" +
                "&street={3}" +
                "&city={4}" +
                "&country={5}" +
                "&gen=9" +
                "&language=fr-fr",
                AppId,
                AppCode,
                PointDepart.GetPointString(),
                PointDestination.GetPointString(),
                LimitePoids.ToString(CultureInfo.InvariantCulture),
                Height.ToString(CultureInfo.InvariantCulture)
                );
            return uri.Uri;
        }
    }
}