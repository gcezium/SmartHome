using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SmartHome.WebApi.Models.OneWire
{
    public class OneWireServerWorker
    {
        public static List<OneWireDeviceDefinition> GetSensorsList()
        {
            List<OneWireDeviceDefinition> result = new List<OneWireDeviceDefinition>();

            try
            {
                WebClient wc = new WebClient();
                string ow_server_response = wc.DownloadString(Config.OneWireServerUrl + "/sensors/list");

                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OneWireDeviceDefinition>>(ow_server_response);

            }
            catch (Exception ex)
            {
            }

            return result;
        }
    }
}