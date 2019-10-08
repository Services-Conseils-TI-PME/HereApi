using Microsoft.Extensions.Configuration;

namespace HereTruckDistance.Core
{
    public class HereRouteRequest : HereRequest
    {
        public HereRouteRequest(IConfiguration config) :base(config, "RouteSrv")
        {
        }
    }

}