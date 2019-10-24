using Here.Models;
using Here.Options.Route;
using System.Threading.Tasks;

namespace Here.Route
{
    public interface IHereRouteTruckService
    {
        Task<CalculDistanceRetourModel> ObtenirDistanceAsync(RouteOptions options);
    }
}