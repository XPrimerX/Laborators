using System.Diagnostics.Tracing;

namespace laboratorka_5
{
    class util_Transport
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
        /*private static DateTime GetRandomDate()
        {
            int year = rnd.Next(1920, 2025);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            Dates = new DateTime(year, month, day);
            return Dates;
        }*/

        /*private static string[][] arr = new string[][]
            {
             new string[] { "Bmw","Porshe","Mercedes" },
             new string[] {"Airbus A380","Boeing 747","Boeing 787 Dreamliner" },
             new string[] { "Merry Fisher","Buster","Yamarin Cross" }
            };*/

        private static Transport generateTransport(int count = 3)
        {
            Dates = new DateTime(rnd.Next(1920, 2025), rnd.Next(1, 13), rnd.Next(1, 28));

            int num = rnd.Next(0, 3);

            transportType = (TransportType)num;

            transportName = arr[num][rnd.Next(arr[num].Length)];

            Detail[] details = new Detail[count];
            for (int i = 0; i < count; i++)
            {
                details[i] = util_inform_detail.generateDetail();
            }

            return new Transport(transportName ?? "None", transportType, Dates, rnd.Next(1000, 100000), details);
        }

        /*private static void GiveMeARandomTypeAndNameOfTheTransportPLEASE()
        {
            switch (rnd.Next(3))
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

        private static double MethodSomeRandomNumberBetweenValues(int minNum = 1000, int maxNum = 100000)
        {
            return rnd.Next(minNum, maxNum);
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
            //GiveMeARandomTypeAndNameOfTheTransportPLEASE();
            A();
            return new Transport(transportName ?? "None", transportType, GetRandomDate(), MethodSomeRandomNumberBetweenValues(), generateDetails());
        }*/
    }
}
