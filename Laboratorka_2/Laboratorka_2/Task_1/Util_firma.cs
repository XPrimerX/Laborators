using Laboratorka_2.Task_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_2.Task_1
{
   public class Util_firma
    {
        private static DateTime Dates;
        public static Random rnd = new Random();
        private static string[] ArrayName =
       {
            "Софія","Анна","Вікторія","Марія","Анастасія","Олександр","Артем","Максим","Богдан","Тимофій"
        };
        private static string[] LastName =
        {
            "White","Black","Коваленко","Бондаренко","Бойко","Ткаченко","Кравченко","Ковальчук","Коваль","Олійник"
        };
        private static string[] Name_firma =
        {
            "Abibas","White","Alroshen","Bananas","Abobe","Asda","Trims","Culturs","Malakurs","Olinus"
        }; 
        private static string[] Profiles =
        {
            "Food","TechSoft","IT","Marketing","Clining","Desiner"
        };
        private static string[] Address =
       {
            "Лондон","Кременчук","Волинь","Київ","Горішні Плавні"
        };
        private static string retPID() 
        { 
            string name= ArrayName[rnd.Next(ArrayName.Length)];
            string lastname = LastName[rnd.Next(LastName.Length)];
            return $"{name} {lastname}";
        }
        private static DateTime retDate()
        {
            int year = rnd.Next(1920, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }
        private static string retNames_firms()
        {
            return Name_firma[rnd.Next(Name_firma.Length)];
        }
        private static string retProfiles()
        {
            return Profiles[rnd.Next(Profiles.Length)];
        }
        private static int retEmployeers()
        {
            return rnd.Next(80, 150);
        }
        private static string retAddress()
        {
            return Address[rnd.Next(Address.Length)];
        }
        public static Firma generateFirma()
        {
            return new Firma(retNames_firms(),retProfiles(),retPID(),retEmployeers(),retAddress(),retDate());
        }
        public static List<Firma> GenerateFirms(int count)
        {
            List<Firma> list = new List<Firma>();
            for (int i = 0; i < count; i++)
                list.Add(generateFirma());
            return list;
        }
    }
}
