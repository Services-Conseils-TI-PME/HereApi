using HereTruckDistance.Core;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace HereTruckDistance.Tests
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

            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, ex);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                ex = (ConfigurationException)bf.Deserialize(ms);
            }

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.Equal(MessageExToString, ex.ToString());
            Assert.Equal(MessageExToString, exceptionToString);
        }
    }
}