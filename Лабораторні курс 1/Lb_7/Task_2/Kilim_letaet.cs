using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    class Kilim_letaet:Device
    {
        public Kilim_letaet(string opis_device) : base(opis_device)
        {
        }
        public override void Infodevice()
        {
            Console.WriteLine($"Килим-літак: {opis_device} (без двигуна)");
        }
        public override object Clone()
        {
            return new Kilim_letaet(opis_device);
        }
    }
}
