using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Standartisation.Logic
{
    public enum BooleanOperation
    {
        [Description("And")]
        AND = 0,

        [Description("Or")]
        OR = 1,

        [Description("And Not")]
        AND_NOT = 2,

        [Description("Or Not")]
        OR_NOT = 3
    }
}
