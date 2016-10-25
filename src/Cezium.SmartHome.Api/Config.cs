using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cezium.SmartHome.Api
{
    public static class Config
    {
        public static string OneWireServerUrl { get { return ConfigurationManager.AppSettings["OneWireSensorUrl"]; } }
        public static string OpenHabServerUrl { get { return ConfigurationManager.AppSettings["OpenHabServerUrl"]; } }
        public static string MySqlConnectionString { get { return ConfigurationManager.AppSettings["MySqlConnectionString"]; } }
    }
}
