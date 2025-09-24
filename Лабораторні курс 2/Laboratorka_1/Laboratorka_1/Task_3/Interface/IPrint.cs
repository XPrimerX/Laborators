using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_3.Interface
{
    internal interface IPrint
    {
        string PID { get; set; }
        int Pages { get; set; }
        int Priority { get; set; }
        DateTime Time { get; set; }

    }
}
