using HereTruckDistance.Api.Properties;
using HereTruckDistance.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HereTruckDistance.Api.Controllers
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

        public HereController(IConfiguration config, ILogger<HereController> logger)
        {
            _config = config;
            _logger = logger;
        }

        // GET: api/Here
        [HttpGet("{format?}")]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogTrace(Resources.LogExecutionFonctionX, "GetAsync");
            HereRouteTruckRequest _Request = new HereRouteTruckRequest(_config);

            HttpClient client = new HttpClient();
            //Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            IActionResult retour;

            var response = await client.GetAsync(_Request.GetRequest()).ConfigureAwait(true);
            if (response.IsSuccessStatusCode)
            {
                retour = Ok(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                retour = BadRequest(response.ReasonPhrase);
            }

            client.Dispose();
            return retour;
        }
    }
}