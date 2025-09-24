using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_2.Interface_and_Utilits
{
    class utilits_minibus
    {
        private static Random rnd = new Random();
        private static string[] ArrayRout =
        {
            "Маршрут №15", "Маршрут №16", "Не_дуже_комфортний_маршрут"
        };
        private static string[] ArrayModern =
        {
            "Супер_модель", "Така_собі", "Елітна"
        };
        private static float retWeigt()
        {
            return rnd.Next(300, 1000);
        }
        private static int retPeople(float weight)
        {
            if (weight > 500)
            {
                return rnd.Next(1, 2);
            }
            else
            {
                return rnd.Next(1, 20);
            }
        }
        private static float retSpeed()
        {
            return rnd.Next(1, 200);
        }
        private static string retRout()
        {
            return ArrayRout[rnd.Next(ArrayRout.Length)];
        }
        private static string retModern(float weight)
        {
            if (weight > 500)
            {
                return "Грузова";
            }
            else
            {
                return ArrayModern[rnd.Next(ArrayModern.Length)];
            }
        }
        public static Minibus generateMiniBus()
        {
            float weight = retWeigt();
            return new Minibus(retPeople(weight), retSpeed(), retRout(), weight,retModern(weight));
        }
    }
}
