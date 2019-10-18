using Microsoft.Extensions.Configuration;

namespace Here.Services
{
    public class HereRouteService : HereService
    {
        public HereRouteService(IConfiguration config) : base(config, "RouteSvc")
        {
        }
    }
}