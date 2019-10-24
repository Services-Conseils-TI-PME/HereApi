using Here.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace Here
{
    public abstract class HereService
    {
        public string Uri { get; private set; }
        public string AppId { get; private set; }
        public string AppCode { get; private set; }

        protected HereService(IConfiguration config, string service)
        {
            if (config is null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (string.IsNullOrEmpty(service))
            {
                throw new ArgumentException(string.Format("Le service Here à utiliser doit être spécifié {0} correctement dans la configuration", service), nameof(service));
            }

            AppId = config.GetSection("HereConfig:AppId").Value;
            AppCode = config.GetSection("HereConfig:AppCode").Value;
            Uri = config.GetSection(string.Format("HereConfig:UriServices:{0}", service)).Value;
            Valider();
        }

        private void Valider()
        {
            if (Uri is null || string.IsNullOrEmpty(Uri))
            {
                throw new ConfigurationException(nameof(Uri));
            }
            if (AppId is null || string.IsNullOrEmpty(AppId))
            {
                throw new ConfigurationException(nameof(AppId));
            }
            if (AppCode is null || string.IsNullOrEmpty(AppCode))
            {
                throw new ConfigurationException(nameof(AppCode));
            }
        }
    }
}
