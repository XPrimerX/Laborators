using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_8.Task_2
{
    class util_element
    {
        public static Random rnd = new Random();
        private static string[] Name =
        {
            "Фен","Книга","Чайник","Каструля"
        };

        private static string retName()
        {
            return Name[rnd.Next(Name.Length)];
        }

        private static double retObem()
        {
            return rnd.Next(1, 5);
        }

        public static Element_do_Valisi genereteElement()
        {
            return new Element_do_Valisi(retName(),retObem());
        }
    }
}
