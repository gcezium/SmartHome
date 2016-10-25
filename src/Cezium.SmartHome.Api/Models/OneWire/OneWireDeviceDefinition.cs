using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SmartHome.Standartisation.HardWare;


namespace Cezium.SmartHome.Api.Models.OneWire
{
    public class OneWireDeviceDefinition
    {
        public string Id { get; set; }
        public SensorMeasureType Type { get; set; }
        public string Value { get; set; }
    }
}