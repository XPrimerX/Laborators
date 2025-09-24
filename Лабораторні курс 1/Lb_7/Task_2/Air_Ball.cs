using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lb_7.Task_2
{
    class Air_Ball : Device
    {
        public Air_Ball(string opis_device) : base(opis_device)
        {
        }
        public override void Infodevice()
        {
            Console.WriteLine($"Повітряна куля: {opis_device} (без двигуна)");
        }
        public override object Clone()
        {
            return new Air_Ball(opis_device);
        }
    }
}
