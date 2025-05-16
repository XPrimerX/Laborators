using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_10
{
    class util_bus
    {
        private static Random rnd = new Random();
        private static int retnomer()
        {
            return rnd.Next(10, 110);
        }
        private static string[] PID =
        {
            "Артем Лисенко", "Мария Ковальчук", "Дмитрий Савченко", "Алина Гриценко", "Максим Зайцев", "Ольга Шевченко", "Владислав Ткаченко"
        };
        private static string[] Punkt =
        {
            "Львів", "Київ", "Одеса","Харків"
        };
        private static string retPID()
        {
            return PID[rnd.Next(PID.Length)];
        }
        private static float retTime()
        {
            return rnd.Next(1, 5);
        }
        private static string retPunkt()
        {
            return Punkt[rnd.Next(Punkt.Length)];
        }
        public static Bus generateBus()
        {
            return new Bus(retnomer(), retPID(), retTime(),retPunkt());
        }
    }
}
