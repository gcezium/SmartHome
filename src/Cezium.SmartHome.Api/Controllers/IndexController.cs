using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cezium.SmartHome.Api.Controllers
{
    [RoutePrefix("")]
    public class IndexController : ApiController
    {
        [Route("")]
        [HttpGet][HttpPost]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}
