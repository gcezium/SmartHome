using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cezium.SmartHome.Api.Controllers
{
    [RoutePrefix("megad")]
    public class MegaDeviceController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            string MegadIp = Request.RequestUri.Host.ToString().Replace(".", "_");
            string MegaDPort = Request.RequestUri.ParseQueryString()["pt"] ?? "";
            string MwgaDPortSwitchMode = Request.RequestUri.ParseQueryString()["m"] ?? "0";

            return "";
        }
    }
}
