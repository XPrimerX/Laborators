using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_6.Task_1.utilits
{
    class util_animals
    {
        private static Random rnd = new Random();
        private static string Name;
        private static string[] ArrayName =
        {
            "Лев", "Тигр", "Антилопа", "Олень"
        };
        private static string retName()
        {
            Name = ArrayName[rnd.Next(ArrayName.Length)];
            return Name;

        }
        private static int retAge()
        {
            return rnd.Next(0, 20); 
        }
        private static double retWeight()
        {
            return rnd.Next(50, 200);
        }
        private static bool retIsWild()
        {
            switch (Name)
            {
                case "Лев":
                    return true;
        
                case "Тигр":
                    return true;
                  
                case "Антилопа":
                    return false;
                   
                case "Олень":
                    return false;
                    
                default:
                    return false;
            }

        }
        public static Animals generateAnimals()
        {
            string name = retName();
            int age = retAge();
            double weight = retWeight();
            bool isWild = retIsWild(); 
            Predatory_animal predatory_Animal = utilits_location.generatePredatory();

            if (isWild)
            {
                return new Wild_animals(name, age, weight, isWild, predatory_Animal);
            }
            else
            {
                return new herbivore_animals(name, age, weight, isWild, predatory_Animal);
            }

        }

    }
}
