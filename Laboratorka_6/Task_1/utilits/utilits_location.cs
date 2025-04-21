using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_1.utilits
{
    class utilits_location
    {
        private static Random rnd = new Random();
        private static string[] ArrayLocation =
        {
            "Африка","Японія","Корея"
        };
        private static string retLocation()
        {
            return ArrayLocation[rnd.Next(ArrayLocation.Length)];

        }
        private static int retPopulation()
        {
            return rnd.Next(0, 5);
        }
        private static double retChangeRate()
        {
            return rnd.Next(0, 10);
        }
        public static Predatory_animal generatePredatory()
        {
            
            return new Predatory_animal(retLocation(), retPopulation(), retChangeRate());
        }

    }
}
