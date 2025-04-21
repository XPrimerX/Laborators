using Laboratorka_6.Task_2.Interface_and_Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_2
{
    class Minibus : Vehicle
    {
        public string route;
        public string modern;
        public Minibus()
        {
            route = "Базова";
            modern = "Базова";
        }
        public Minibus(int people, float speed, string route, float weight, string modern) : base(people, speed, weight)
        {
            this.route = route;
            this.modern = modern;
        }
        public string Route
        {
            get { return route; }
            set
            {
                if (value.Length < 100) route = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Modern
        {
            get { return modern; }
            set
            {
                if (value.Length < 100) modern = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return "Маршрутне таксі " + modern + base.ToString() + "\nМаршрут : " +route;

        }

    }
}
