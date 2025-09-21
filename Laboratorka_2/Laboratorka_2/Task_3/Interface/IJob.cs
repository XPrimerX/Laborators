using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_2.Task_3.Interface
{
    internal interface IJob
    {
        string Position { get; set; }
        float Salary { get; set; }
        int Opit { get; set; }
        string LevelofEducation { get; set; }
    }
}
