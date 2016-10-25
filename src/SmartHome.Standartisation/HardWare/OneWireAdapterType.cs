using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cezium.SmartHome.Standartisation.HardWare
{
    public enum OneWireAdapterType
    {
        [Description("DS9490")]
        DS9490 = 0,

        [Description("DS9097U")]
        DS9097U = 1,

        [Description("DS1410E")]
        DS1410E = 2,

        [Description("DS9097E")]
        DS9097E = 3
    }
}
