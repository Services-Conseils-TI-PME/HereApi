using System;
using System.Runtime.Serialization;

namespace HereTruckDistance.Core
{
    [Serializable]
    public class ConfigurationException : Exception
    {
        private const string MessageFormat = "La valeur {0} n'est pas configuré correctement";

        public ConfigurationException()
        {
        }

        public ConfigurationException(string configValue) : 
            base(string.Format(MessageFormat, configValue))
        {
        }

        public ConfigurationException(string configValue, Exception innerException) :
            base(string.Format(MessageFormat, configValue), innerException)
        {
        }

        protected ConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}