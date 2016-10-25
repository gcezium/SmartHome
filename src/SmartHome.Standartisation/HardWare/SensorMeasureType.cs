using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cezium.SmartHome.Standartisation.HardWare
{
    public enum SensorMeasureType
    {
        [Description("Не указано")]
        Unknown = 0,

        [Description("Температура")]
        Temperature = 1,

        [Description("Освещённость")]
        Light = 2,

        [Description("Влажность")]
        Humidity = 3,
    }
}
