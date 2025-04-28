using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    class util_inform_detail_lb5
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
        public static Detail_from_lb5 generateDetail()
        {
            Person_from_lb5 manufacturer = util_Person_from_lb5.generatePerson();
            return new Detail_from_lb5(manufacturer, retOpis(), retWeight());
        }
    }
}
