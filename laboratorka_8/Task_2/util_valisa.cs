using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_8.Task_2
{
    class util_valisa
    {
        public static Random rnd = new Random();
        private static string[] Color =
        {
            "Жовтий","Синій","Червоний"
        };
        private static string[] Firma =
        {
            "Гучі","Луївітон","Прада"
        };
        private static string retColor()
        {
           return Color[rnd.Next(Color.Length)];
        }
        private static string retFirma()
        {
            return Firma[rnd.Next(Firma.Length)];
        }
        private static double retWeight()
        {
            return rnd.Next(3, 10); 
        }
        private static double retObem()
        {
            return rnd.Next(20, 80);
        }
        public static Valisa genereteValisa()
        {
            return new Valisa(retColor(), retFirma(), retWeight(), retObem());
        }
    }
}
