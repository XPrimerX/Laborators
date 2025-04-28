using Lb_7.Task_2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    public abstract class Device: IDevice,ICloneable
    {
        public string opis_device { get; set; }
        
        public Device(string opis_device)
        {
            this.opis_device = opis_device;
        }
        public abstract void Infodevice();
        public abstract object Clone();
    }
}
