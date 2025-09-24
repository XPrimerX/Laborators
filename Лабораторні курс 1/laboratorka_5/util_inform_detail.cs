using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_5
{
    class util_inform_detail
    {
        public static Random rnd = new Random();
        
        private static string[] Opis_detail =
        {
            "Двигун","Колесо","Крісло","Двері"
        };
        private static string retOpis()
        {
            return Opis_detail[rnd.Next(Opis_detail.Length)];
        }
        private static double retWeight()
        {
            return rnd.Next(100, 1000);
        }
        public static Detail generateDetail()
        {
            Person manufacturer = util_Person.generatePerson();
            return new Detail(manufacturer,retOpis(), retWeight());
        }

    }
}
