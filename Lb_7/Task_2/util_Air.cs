using Lb_7.Task_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_2
{
    class util_Air
    {
        private static string? transportName;
        private static string? transportMotor;
        public static Random rnd = new Random();

        private static string[] Air_ball =
        {
            "Red_ball","Green_ball","Black_ball"
        };
        private static string[] Deltaplan =
        {
            "Red_Deltaplan","Green_Deltaplan","Black_Deltaplan"
        };
        private static string[] Helicopter =
        {
            "АК1-3","КТ-112","Skyline"
        };
        private static string[] Kilim =
       {
            "Kilim_Aladina","Turbo_kilim","low_kilim"
        };
        private static string[] Plane =
       {
            "Airbus A380","Boeing 747","Boeing 787 Dreamliner"
        };
        private static string[] Motor =
      {
            "Forte F200G","Forte F210GS-20","Forte F210G"
        };
       public static Device GetRandomTransporte()
        {
            int choice = rnd.Next(5);

            switch (choice)
            {
                case 0:
                    transportName = Air_ball[rnd.Next(Air_ball.Length)];
                    return new Air_Ball(transportName);
                case 1:
                    transportName = Deltaplan[rnd.Next(Deltaplan.Length)];
                    return new Deltaplan(transportName);
                case 2:
                    transportName = Helicopter[rnd.Next(Helicopter.Length)];
                    transportMotor = Motor[rnd.Next(Motor.Length)];
                    return new Helicopter(transportName, transportMotor);
                case 3:
                    transportName = Kilim[rnd.Next(Kilim.Length)];
                    return new Kilim_letaet(transportName);
                case 4:
                    transportName = Plane[rnd.Next(Plane.Length)];
                    transportMotor = Motor[rnd.Next(Motor.Length)];
                    return new Plane(transportName, transportMotor);
                default:
                    throw new InvalidOperationException("Невірний вибір транспорту.");
            }
        }
    }
}
