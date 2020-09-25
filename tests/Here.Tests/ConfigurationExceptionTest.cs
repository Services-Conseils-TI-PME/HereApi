using Here.Configuration;
using System;
using System.Text.Json;
using Xunit;

namespace Here.Tests
{
    public class ConfigurationExceptionTest
    {
        private const string MessageExToString = "ex.ToString()";
        private const string Message = "Message";
        private const string InnerException = "Inner exception.";

        public ConfigurationExceptionTest()
        {
        }

        [Fact]
        public void TestConfigurationException()
        {
            Exception ex =
                new ConfigurationException(
                    Message, new Exception(InnerException));

            // Save the full ToString() value, including the exception message and stack trace.
            string exceptionToString = ex.ToString();

            // "Save" object state
            string serializedData = JsonSerializer.Serialize(ex);

            // Replace the original exception with de-serialized one
            ex = JsonSerializer.Deserialize<ConfigurationException>(serializedData);

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.Equal(exceptionToString, ex.ToString());
        }
    }
}