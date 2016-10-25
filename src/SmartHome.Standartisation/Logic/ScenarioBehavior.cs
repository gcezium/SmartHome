using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Standartisation.Logic
{
    public enum ScenarioBehavior
    {
        [Description("При опросе датчиков")]
        OnSensorPoll = 0,

        [Description("При поступлении входного сигнала")]
        OnSignal = 1,
    }
}
