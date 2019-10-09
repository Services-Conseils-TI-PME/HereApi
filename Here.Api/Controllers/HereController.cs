using Here.Api.Properties;
using Here.Geocoder;
using Here.Models;
using Here.Options.Geocoder;
using Here.Options.Route;
using Here.Route;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Here.Api.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class HereController : ControllerBase
    {
        private readonly ILogger<HereController> _logger;
        private readonly IConfiguration _config;
        private readonly IHereRouteTruckService _routeSrv;
        private readonly IHereGeocodeService _geoSrv;


        public HereController(ILogger<HereController> logger, IConfiguration config, IHereRouteTruckService routeSrv, IHereGeocodeService geoSrv)
        {
            _config = config;
            _logger = logger;
            _routeSrv = routeSrv;
            _geoSrv = geoSrv;
        }

        // GET: api/Here
        [HttpGet("{format?}")]
        public async Task<IActionResult> GetAsync()
        {
            HttpClient client = new HttpClient();
            //Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            IActionResult retour = null;

            //TODO: Devrait être reçu en paramètre!
            RouteDistanceModel parametres = new RouteDistanceModel();

            //Obtenir le point Géolocalisé pour l'origine et la destination
            var geoOptions = new GeocoderOptions();
            geoOptions.AddAdresse(parametres.Depart);
            var origine = await _geoSrv.ObtenirLocalisationAsync(geoOptions).ConfigureAwait(false);

            geoOptions = new GeocoderOptions();
            geoOptions.AddAdresse(parametres.Destination);
            var destination = await _geoSrv.ObtenirLocalisationAsync(geoOptions).ConfigureAwait(false);

            //Construire les options de recherche
            var options = new RouteTruckOptions();
            options.AddLocalisation(origine, 0);
            options.AddLocalisation(destination, 1);
            options.AddMode(new Mode[] { Mode.fastest, Mode.truck, Mode.trafficDisabled });
            options.AddLimitedWeight(parametres.Poids);
            options.AddLength(parametres.Longueur);
            options.AddWidth(parametres.Largeur);

            //Obtenir la distance "Camion" entre 2 points géolocalisés
            try
            {
                var retourSrv = await _routeSrv.ObtenirDistanceAsync(options).ConfigureAwait(false);
                retour = Ok(retourSrv);
            }
            catch (Exception)
            {
                retour = BadRequest("Une erreur est survenue lors de l'appel du service");
            }

            client.Dispose();
            return retour;
        }

    }
}
