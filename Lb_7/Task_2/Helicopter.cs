using Lb_7.Task_2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    class Helicopter : Device, IEngine
    {

        public string opis_motor { get; }
        public bool IsHaveMotor => true;

        public Helicopter(string opis_device, string opis_motor) : base(opis_device)
        {
            this.opis_motor = opis_motor;
        }
        public override void Infodevice()
        {
            Console.WriteLine($"Вертоліт: {opis_device}, Двигун: {opis_motor}");
        }
        public override object Clone()
        {
            return new Helicopter(opis_device, opis_motor);
        }
    }
}
