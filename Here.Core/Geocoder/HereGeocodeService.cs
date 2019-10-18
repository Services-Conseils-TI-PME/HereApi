using Here.Options.Geocoder;
using Here.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Here.Geocoder
{
    public class HereGeocodeService : HereService, IHereGeocodeService
    {
        public HereGeocodeService(IConfiguration config) : base(config, "GeocoderSvc")
        {
        }

        private Uri ObtenirUri(GeocoderOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            //TODO: À changer pour un string builder
            UriBuilder uri = new UriBuilder(Uri);

            uri.Query = string.Format("{2}&language=fr-ca&app_id={0}&app_code={1}", AppId, AppCode, options.ToString());

            return uri.Uri;
        }

        public async Task<Localisation> ObtenirLocalisationAsync(GeocoderOptions options)
        {
            HttpClient client = new HttpClient();
            //Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string retourSvc;
            Localisation retour;

            var response = await client.GetAsync(ObtenirUri(options)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                //TODO: Doit être traité et retourné dans un RouteCamionModel
                //Newtonsoft.Json.JO
                JObject retourJson = (JObject)JToken.Parse(response.Content.ReadAsStringAsync().Result).SelectToken("Response.View[*].Result[0].Location.NavigationPosition[*]");
                retour = new Localisation(retourJson.SelectToken("Latitude").Value<decimal>(),
                                          retourJson.SelectToken("Longitude").Value<decimal>()
                                          );
            }
            else
            {
                retour = null;
            }

            client.Dispose();
            return retour;
        }
    }
}
