using System;
using System.Collections.Generic;
using System.Text;

namespace HereTruckDistance.Core
{
    public interface IHereRouteRequest
    {
        Localisation PointDepart { get; set; }
        Localisation PointDestination { get; set; }
        IList<string> Mode { get; set; }
        bool Trafic { get; set; }
        decimal LimitePoids { get; set; }
        decimal Height { get; set; }
        string ShippedHazardousGoods { get; set; }
    }
}
