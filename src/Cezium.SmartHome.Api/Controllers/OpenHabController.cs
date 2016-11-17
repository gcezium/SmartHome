using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cezium.SmartHome.Api.Controllers
{
    // TODO
    // CORRECTLY SETUP CORS PORT
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("openhab")]
    public class OpenHabController : ApiController
    {
        [Route("item/{name}")]
        [HttpGet]
        public IHttpActionResult GetItem(string name)
        {
            return Ok(WebApiApplication.OpenHabService.GetItem(name));
        }


        [Route("switch/{name}")]
        [HttpPost][HttpGet]
        public IHttpActionResult Switch(string name)
        {
            return Ok(WebApiApplication.OpenHabService.Switch(name));
        }


        [Route("setstate/{name}/{state}")]
        [HttpGet][HttpPost]
        public IHttpActionResult SetState(string name, string state)
        {
            return Ok(WebApiApplication.OpenHabService.ChangeState(name, state));
        }
    }
}
