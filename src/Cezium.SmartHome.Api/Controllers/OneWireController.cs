using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using SmartHome.WebApi.Models.OneWire;

namespace Cezium.SmartHome.Api.Controllers
{
    [RoutePrefix("onewire")]
    public class OneWireController : ApiController
    {
        [HttpGet]
        [Route("devices")]
        public List<OneWireDeviceDefinition> Devices()
        {
            return OneWireServerWorker.GetSensorsList();
        }

        [HttpGet]
        [Route("devices/{id}")]
        public string Devices(string id)
        {
            string result = "";

            try
            {
                WebClient wc = new WebClient();
                result = wc.DownloadString(Config.OneWireServerUrl + "/sensors/read/" + id.ToString());
            }
            catch (Exception ex)
            {
                
            }

            return result;
        }
    }
}
