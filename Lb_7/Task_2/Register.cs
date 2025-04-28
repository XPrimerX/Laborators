using Lb_7.Task_2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    class Register
    {
        private List<Device> devices = new List<Device>();

        public void AddDevice(Device device)
        {
            devices.Add(device);
        }
        public void AddRemove(Device device)
        {
            devices.Remove(device);
        }
        public void DisplayAll()
        {
            Console.WriteLine("Усе обладнання:");
            foreach (var device in devices)
            {
                device.Infodevice();
            }
        }
        public void Havemotor()
        {
            Console.WriteLine("Обладнання з двигунами:");
            foreach (var device in devices)
            {
                if (device is IEngine engineDevice && engineDevice.IsHaveMotor)
                {
                    device.Infodevice();
                }
            }
        }
        public void Nohavemotor()
        {
            Console.WriteLine("Обладнання без двигунів:");
            foreach (var device in devices)
            {
                if (!(device is IEngine))
                {
                    device.Infodevice();
                }
            }
        }
        public void SortByName()
        {
            devices = devices.OrderBy(device => device.opis_device).ToList();
        }
    }
}
