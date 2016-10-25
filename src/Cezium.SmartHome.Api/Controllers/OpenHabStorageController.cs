using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Cezium.SmartHome.OpenHabDb.Models.OpenHabItemsDbClient;
using Cezium.SmartHome.Api;
using Cezium.SmartHome.Api.Serialization.OpenHabStorage;

namespace SmartHome.Api.Controllers
{
    [RoutePrefix("openhabstorage")]
    // TODO
    // CORRECTLY SETUP CORS PORT
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OpenHabStorageController : ApiController
    {
        private OpenHabItemsDbClient client = new OpenHabItemsDbClient();

        public OpenHabStorageController()
        {
            try
            {
                client.Connect(Config.MySqlConnectionString);
            }
            catch (Exception ex)
            {
                WebApiApplication.Logger.Error("OpenHabItemsDbClient init error:\r\n" + ex.ToString());
 
                client = null;
            }
        }

        [Route("items")]
        [HttpGet][HttpPost]
        public List<OpenHabItem> Index()
        {
            var result = new List<OpenHabItem>();

            if (client != null)
            {
                result = client.Items.Select(i => new OpenHabItem()
                    {
                        Id = i.Id,
                        Name = i.Name
                    }).ToList();
            }

            return result;
        }

        [Route("items/{name}/values/all")]
        [HttpGet]
        [HttpPost]
        public List<OpenHabItemValue> GetAllValues(string name)
        {
            var result = new List<OpenHabItemValue>();

            if (client != null)
            {
                var item = client.Items.FirstOrDefault(i => i.Name == name);

                if (item != null)
                {
                    result = item.GetValues().Select(v => new OpenHabItemValue(){ 
                        DateTime = v.DateTime,
                        Value = v.Value
                    }).ToList();
                }
            }

            return result;
        }


        [Route("items/{name}/values/top/{count:int}")]
        [HttpGet]
        [HttpPost]
        public List<OpenHabItemValue> GetAllValues(string name, int count)
        {
            var result = new List<OpenHabItemValue>();

            if (client != null)
            {
                var item = client.Items.FirstOrDefault(i => i.Name == name);

                if (item != null)
                {
                    result = item.GetValues(count)
                        .OrderBy(c => c.DateTime)
                        .Select(v => new OpenHabItemValue()
                    {
                        DateTime = v.DateTime,
                        Value = v.Value
                    }).ToList();
                }
            }

            return result;
        }


        [Route("items/{name}/values/from/{startDate:datetime}/to/{stopDate:datetime}")]
        [HttpGet]
        [HttpPost]
        public List<OpenHabItemValue> GetAllValues(string name, DateTime startDate, DateTime stopDate)
        {
            var result = new List<OpenHabItemValue>();

            if (client != null)
            {
                var item = client.Items.FirstOrDefault(i => i.Name == name);

                if (item != null)
                {
                    result = item.GetValues(startDate, stopDate)
                        .OrderBy(c => c.DateTime)
                        .Select(v => new OpenHabItemValue()
                        {
                            DateTime = v.DateTime,
                            Value = v.Value
                        }).ToList();
                }
            }

            return result;
        }

        [Route("items/{name}/values/daysbefore/{days:int}")]
        [HttpGet]
        [HttpPost]
        public List<OpenHabItemValue> GetAllValuesByDay(string name, int days)
        {
            var result = new List<OpenHabItemValue>();

            if (client != null)
            {
                var item = client.Items.FirstOrDefault(i => i.Name == name);

                if (item != null)
                {
                    result = item.GetValues(new TimeSpan(days, 0, 0, 0))
                        .OrderBy(c => c.DateTime)
                        .Select(v => new OpenHabItemValue()
                        {
                            DateTime = v.DateTime,
                            Value = v.Value
                        }).ToList();
                }
            }

            return result;
        }
    }
}
