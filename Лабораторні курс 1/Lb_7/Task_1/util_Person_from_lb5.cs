using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    class util_Person_from_lb5
    {
        private static DateTime Dates;
        public static Random rnd = new Random();
        private static string[] ArrayName =
        {
            "Софія","Анна","Вікторія","Марія","Анастасія","Олександр","Артем","Максим","Богдан","Тимофій"
        };
        private static string[] LastName =
        {
            "Мельник","Шевченко","Коваленко","Бондаренко","Бойко","Ткаченко","Кравченко","Ковальчук","Коваль","Олійник"
        };
        private static string retName()
        {
            return ArrayName[rnd.Next(ArrayName.Length)];

        }
        private static string retLastName()
        {
            return LastName[rnd.Next(LastName.Length)];
        }
        private static DateTime retDate()
        {
            int year = rnd.Next(1920, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }
        public static Person_from_lb5 generatePerson()
        {
            return new Person_from_lb5(retName(), retLastName(), retDate());
        }

    }
}
