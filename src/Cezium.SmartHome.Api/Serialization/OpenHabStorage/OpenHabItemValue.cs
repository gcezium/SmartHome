using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cezium.SmartHome.Api.Serialization.OpenHabStorage
{
    public class OpenHabItemValue
    {
        public DateTime DateTime { get; set; }
        public string Value { get; set; }
    }
}