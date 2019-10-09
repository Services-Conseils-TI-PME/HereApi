using Here.Options.Route;
using Here.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Here.Route
{
    public class HereRouteTruckService : HereRouteService, IHereRouteTruckService
    {
        public HereRouteTruckService(IConfiguration config) : base(config)
        {
        }

        private Uri ObtenirUri(RouteOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            //TODO: À changer pour un string builder
            UriBuilder uri = new UriBuilder(Uri);

            uri.Query = string.Format("app_id={0}&app_code={1}{2}", AppId, AppCode, options.ToString());

            return uri.Uri;
        }

        public async Task<string> ObtenirDistanceAsync(RouteOptions options)
        {
            HttpClient client = new HttpClient();
            //Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            string retour;

            var response = await client.GetAsync(ObtenirUri(options)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                //TODO: Doit être traité et retourné dans un RouteCamionModel
                retour = response.Content.ReadAsStringAsync().Result.ToString();
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