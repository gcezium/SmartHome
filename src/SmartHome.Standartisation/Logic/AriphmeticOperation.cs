using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Standartisation.Logic
{
    public enum AriphmeticOperation
    {
        [Description("=")]
        Equal = 0,

        [Description("!=")]
        NotEqual = 1,

        [Description(">")]
        MoreThan = 2,

        [Description("<")]
        LessThan = 3,

        [Description(">=")]
        MoreOrEqual = 4,

        [Description("<=")]
        LessOrEqual = 5,
    }
}
