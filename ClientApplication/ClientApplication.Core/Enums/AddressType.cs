using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Core.Enums
{
    public enum AddressTypes
    {
        [Description("Home Address")]
        HomeAddress = 1,
        [Description("Weekend Address")]
        WeekendAddress = 2,
        [Description("Work Address")]
        WorkAddress = 3
    }
}
