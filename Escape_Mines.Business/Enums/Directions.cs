using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Escape_Mines.Business.Enums
{
    [Flags]
    public enum Directions
    {
        [DisplayName("North")]
        N = 1,
        [DisplayName("East")]
        E = 2,
        [DisplayName("South")]
        S = 4,
        [DisplayName("West")]
        W = 8
    }
}
