using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_2.Task_2
{
    public class Util_phone
    {
        private static DateTime Dates;
        public static Random rnd = new Random();
        private static string[] Name =
        {
            "IPhone 12","IPhone 10","Galaxy Pro","Galaxy","Poco","Poco x6 pro"
        };
        private static string retName()
        {
            return Name[rnd.Next(Name.Length)];
        }
        private static DateTime retDate()
        {
            int year = rnd.Next(2000, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }
        private static string retFirms(string name)
        {
            if (name.StartsWith("IPhone")) return "Apple";
            if (name.StartsWith("Galaxy")) return "Samsung";
            if (name.StartsWith("Poco")) return "Xiaomi";
            return "Unknown";
        }
        private static float retPrice()
        {
            return rnd.Next(50, 700);
        }
        public static Phone generatePhone()
        {
            string name = retName();
            return new Phone(name,retFirms(name),retPrice(),retDate());
        }
        public static List<Phone> GeneratePhones(int count)
        {
            List<Phone> list = new List<Phone>();
            for (int i = 0; i < count; i++)
                list.Add(generatePhone());
            return list;
        }
    }
}
