using Laboratorka_6.Task_2.Interface_and_Utilits;
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
        public string modern;
        public Bus()
        {
            Company = "Базова";
            modern = "Базова";
        }
        public Bus(int people, float speed, string Company, float weight, string modern) : base(people, speed, weight)
        {
            this.Company = Company;
            this.modern = modern;
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
            return "Автобус" +modern + base.ToString() +  "\nКомпанія: " + Company;

        }

    }
}
