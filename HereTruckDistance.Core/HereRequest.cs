using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace HereTruckDistance.Core
{
    public abstract class HereRequest
    {
        public string Uri { get { return _config.HereUri; } }
        public string AppId { get { return _config.HereAppId; } }
        public string AppCode { get { return _config.HereAppCode; } }
        public string Service { get; set; }

        protected readonly HereConfig _config;

        protected HereRequest(IConfiguration config)
        {
            _config = new HereConfig();
            _config.HereUri = config.GetSection("HereConfig:HereUri").Value;
            _config.HereAppId = config.GetSection("HereConfig:HereAppId").Value;
            _config.HereAppCode = config.GetSection("HereConfig:HereAppCode").Value;
        }

        public Uri GetUri()
        {
            Valider();

            var retourUri = new UriBuilder(Uri);
            retourUri.Query = Service;

            return retourUri.Uri;
        }

        private void Valider()
        {
            if (Uri is null || Uri.Length == 0) {
                throw new ConfigurationException(nameof(Uri));
            }
            if (AppId is null || AppId.Length == 0)
            {
                throw new ConfigurationException(nameof(AppId));
            }
            if (AppCode is null || AppCode.Length == 0)
            {
                throw new ConfigurationException(nameof(AppCode));
            }

            if (Service is null || Service.Length == 0)
            {
                throw new ConfigurationException(nameof(Service));
            }
        }
    }

}