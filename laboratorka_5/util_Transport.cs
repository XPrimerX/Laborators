using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_5
{
    class util_Transport
    {
        private static double price;
        private static string transport;
        private static System.DateTime Dates;
        public static Random rnd = new Random();

        private static string[] Transport =
        {
            "Автомобіль","Літак","Катер"
        };
        private static System.DateTime retDate()
        {
            int year = rnd.Next(1920, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }
        private static string retTransport()
        {
            transport = Transport[rnd.Next(Transport.Length)];
            return transport;
        }
        private static TransportType retTyp()
        {
            switch (transport)
            {
                case "Автомобіль":
                    return TransportType.Ground;
                case "Літак":
                    return TransportType.Air;
                case "Катер":
                    return TransportType.Water;
                default:
                    return TransportType.Ground;
            }
        }

        private static double retprice()
        {
            return price = rnd.Next(10000, 1000000);
        }

        private static Detail[] generateDetails(int count = 3)
        {
            Detail[] details = new Detail[count];
            for (int i = 0; i < count; i++)
            {
                details[i] = util_inform_detail.generateDetail();
            }
            return details;
        }
        public static Transport generateTransport()
        {
            Person manufacturer = util_Person.generatePerson();
            return new Transport(retTransport(), retTyp(), retDate(), retprice(), generateDetails());
        }
    }
}
