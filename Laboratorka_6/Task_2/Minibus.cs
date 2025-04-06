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
        public Minibus()
        {
            people = 0;
            speed = 0;
            route = "Базова";
        }
        public Minibus(int people, float speed, string route) : base(people, speed)
        {
            this.route = route;
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
        public override string ToString()
        {
            return "Маршрутне таксі " + base.ToString() + "\nМаршрут : " +route;

        }

    }
}
