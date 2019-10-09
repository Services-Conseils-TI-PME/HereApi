using Here.Options.Route;
using System.Threading.Tasks;

namespace Here.Route
{
    public interface IHereRouteTruckService
    {
        Task<string> ObtenirDistanceAsync(RouteOptions options);
    }
}