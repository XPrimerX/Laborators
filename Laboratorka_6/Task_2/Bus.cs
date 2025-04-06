using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_2
{
    class Bus : Vehicle
    {
        public string Company;
        public Bus()
        {
            people = 0;
            speed = 0;
            Company = "Базова";
        }
        public Bus(int people, float speed, string Company) : base(people, speed)
        {
            this.Company = Company;
        }

        public string company
        {
            get { return Company; }
            set
            {
                if (value.Length < 100) Company = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return "Автобус" + base.ToString() +  "\nКомпанія: " + Company ;

        }

    }
}
