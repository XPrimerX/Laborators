using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_2.Interface_and_Utilits
{
    class utilits_car
    {
        private static string[] ArrayModern =
        {
            "Супер_модель", "Така_собі", "Елітна"
        };
        private static Random rnd = new Random();
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
       
        private static float retWeigt()
        {

            return rnd.Next(300, 1000);
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
        public static Car generateCar()
        {
            float weight = retWeigt();
            return new Car(retPeople(weight), retSpeed(), retModern(weight), weight);
        }
    }
}
