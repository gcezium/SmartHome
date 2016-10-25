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
    [RoutePrefix("openhab")]
    // TODO
    // CORRECTLY SETUP CORS PORT
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OpenHabController : ApiController
    {
        [Route("item")]
        [HttpGet]
        public HttpResponseMessage GetItem(string name)
        {
            string service_response = WebApiApplication.OpenHabService.GetItem(name);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            response.Content = new StringContent(service_response, Encoding.UTF8, "application/json");

            return response;
        }
        /*
        [Route("items")]
        [HttpGet]
        public HttpResponseMessage GetItem(string[] names)
        {
            string service_response = WebApiApplication.OpenHabService.GetItem(name);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            response.Content = new StringContent(service_response, Encoding.UTF8, "application/json");

            return response;
        }
        */


        [Route("switch")]
        [HttpPost][HttpGet]
        public HttpResponseMessage Switch(string name)
        {
            string service_response = WebApiApplication.OpenHabService.Switch(name);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            response.Content = new StringContent(service_response, Encoding.UTF8, "application/json");

            return response;
        }

        [Route("setstate")]
        [HttpGet][HttpPost]
        public HttpResponseMessage SetState(string name, string state)
        {
            string service_response = WebApiApplication.OpenHabService.ChangeState(name, state);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "");
            response.Content = new StringContent(service_response, Encoding.UTF8, "application/json");

            return response;
        }
    }
}
