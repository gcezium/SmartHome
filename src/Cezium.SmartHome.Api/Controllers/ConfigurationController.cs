using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cezium.SmartHome.Api.Models.Configuration;
using Cezium.SmartHome.Api.Models;

namespace Cezium.SmartHome.Api.Controllers
{
    [RoutePrefix("configuration")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConfigurationController : ApiController
    {
        [Route("read")]
        [HttpGet]
        public Configuration Read()
        {
            return WebApiApplication.ConfigurationService.Read();
        }

        [Route("write")]
        [HttpPost]
        public ApiResponse Write([FromBody] Configuration configuration)
        {
            try
            {
                WebApiApplication.ConfigurationService.Write(configuration);
                return new ApiResponse(true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false) { Esception = ex };
            }
        }
    }
}
