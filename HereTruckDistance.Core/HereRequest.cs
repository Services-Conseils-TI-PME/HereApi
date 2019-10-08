using Microsoft.Extensions.Configuration;
using System;

namespace HereTruckDistance.Core
{
    public abstract class HereRequest
    {
        protected string AppId { get; private set; }
        protected string AppCode { get; private set; }
        protected string ServiceUri { get; private set; }

        protected HereRequest(IConfiguration config, string service)
        {
            AppId = config.GetSection("HereConfig:AppId").Value;
            AppCode = config.GetSection("HereConfig:AppCode").Value;
            ServiceUri = config.GetSection("HereConfig:UriServices:RouteSrv").Value;
        }

        private void Valider()
        {
            if (AppId is null || AppId.Length == 0)
            {
                throw new ConfigurationException(nameof(AppId));
            }
            if (AppCode is null || AppCode.Length == 0)
            {
                throw new ConfigurationException(nameof(AppCode));
            }
            if (ServiceUri is null || string.IsNullOrEmpty(ServiceUri))
            {
                throw new ConfigurationException(nameof(Uri));
            }
        }
    }
}