using Here.Options.Geocoder;
using System.Threading.Tasks;

namespace Here.Geocoder
{
    public interface IHereGeocodeService
    {
        Task<Localisation> ObtenirLocalisationAsync(GeocoderOptions options);
    }
}