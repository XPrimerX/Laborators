using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    class Deltaplan:Device
    {
        public Deltaplan(string opis_device) : base(opis_device)
        {
        }
        public override void Infodevice()
        {
            Console.WriteLine($"Дельтаплан: {opis_device} (без двигуна)");
        }
        public override object Clone()
        {
            return new Deltaplan(opis_device);
        }
    }
}
