using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    class util_Transport_from_lb5
    {
        private static DateTime Dates;
        public static Random rnd = new Random();
        private static string? transportName;
        private static TransportType transportType;

        private static string[] Car =
        {
            "Bmw","Porshe","Mercedes"
        };
        private static string[] Plane =
       {
            "Airbus A380","Boeing 747","Boeing 787 Dreamliner"
        };
        private static string[] Ship =
       {
            "Merry Fisher","Buster","Yamarin Cross"
        };
        private static DateTime retDate()
        {
            int year = rnd.Next(1920, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }
        private static void retTransportAndType()
        {
            int choice = rnd.Next(3);

            switch (choice)
            {
                case 0:
                    transportName = Car[rnd.Next(Car.Length)];
                    transportType = TransportType.Ground;
                    break;
                case 1:
                    transportName = Plane[rnd.Next(Plane.Length)];
                    transportType = TransportType.Air;
                    break;
                case 2:
                    transportName = Ship[rnd.Next(Ship.Length)];
                    transportType = TransportType.Water;
                    break;
            }
        }

        private static double retprice()
        {
            return rnd.Next(1000, 100000);
        }

        private static Detail_from_lb5[] generateDetails(int count = 3)
        {
            Detail_from_lb5[] details = new Detail_from_lb5[count];
            for (int i = 0; i < count; i++)
            {
                details[i] = util_inform_detail_lb5.generateDetail();
            }
            return details;
        }
        public static Transport_from_lb5 generateTransport()
        {
            retTransportAndType();

            return new Transport_from_lb5(transportName ?? "None", transportType, retDate(), retprice(), generateDetails());
        }
    }
}
