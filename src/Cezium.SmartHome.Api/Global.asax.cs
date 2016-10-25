using Cezium.SmartHome.Api.Models.Configuration;
using Cezium.SmartHome.Api.Models.OpenHab;
using System.Web;
using System.Web.Http;

namespace Cezium.SmartHome.Api
{
    public class WebApiApplication : HttpApplication
    {
        private static OpenHabService _openhabService = null;
        public static OpenHabService OpenHabService { get { return _openhabService; } }

        private static ConfigurationService _configurationService = null;
        public static ConfigurationService ConfigurationService { get { return _configurationService; } }

        public static NLog.Logger Logger { get; set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            _openhabService = new OpenHabService(Config.OpenHabServerUrl);

            _configurationService = new ConfigurationService();

            Logger = NLog.LogManager.GetCurrentClassLogger();
        }
    }
}
