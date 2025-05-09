using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_8.Task_1
{
   public class Method_Task_1
    {
        //static void Time_Now()
        //{
        //    Console.WriteLine("Час зараз: " + DateTime.Now.ToShortTimeString());
        //}
        public static Action Time_Now =() => Console.WriteLine("Час зараз: " + DateTime.Now.ToShortTimeString());

        //static void Date_Now()
        //{
        //    Console.WriteLine("Дата зараз: " + DateTime.Now.ToShortDateString());
        //}
        public static Action Date_Now = () => Console.WriteLine("Дата зараз: " + DateTime.Now.ToShortDateString());

        //static void Day_Now()
        //{
        //    Console.WriteLine("Поточний день тижня зараз: " + DateTime.Now.DayOfWeek);
        //}
        public static Action Day_Now = () => Console.WriteLine("Поточний день тижня зараз: " + DateTime.Now.DayOfWeek);

        //static bool Prostoe_or_not(int number)
        //{
        //    for (int i = 2; i <= Math.Sqrt(number); i++)
        //    {
        //        if (number % i == 0) return false;

        //    }
        //    return true;
        //}

        public static Predicate<int> Prostoe_or_not = number =>
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        };

        //static bool Fibanachi(int number)
        //{
        //    //Формула (5*n^2 + 4) або (5*n^2 - 4)
        //    int forml1 = 5 * number * number + 4;
        //    int forml2 = 5 * number * number - 4;
        //    int x = (int)Math.Sqrt(forml1);
        //    int y = (int)Math.Sqrt(forml2);
        //    if (x*x == forml1 || y*y == forml2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static Predicate<int> Fibanachi = number =>
        {
            int forml1 = 5 * number * number + 4;
            int forml2 = 5 * number * number - 4;
            int x = (int)Math.Sqrt(forml1);
            int y = (int)Math.Sqrt(forml2);
            return x * x == forml1 || y * y == forml2;
        };


        //static int plosha_trekutnika(int h,int a)
        //{
        //    int S = 0.5 * a * h;
        //    return S;
        //}
        public static Func<double, double, double> plosha_trekutnika = (a, h) => 0.5 * a * h;
        public static Func<int, int, int> plosha_pramokut = (a, b) => a * b;

    }
}


