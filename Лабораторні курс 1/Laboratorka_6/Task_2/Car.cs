using Laboratorka_6.Task_2.Interface_and_Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_6.Task_2
{
    class Car : Vehicle
    {
        public string modern;
        public Car()
        {
            modern = "Базова";
        }
        public Car(int people, float speed,string modern,float weight) : base(people,speed,weight)
        {
            this.modern = modern;
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
            return "Автомобіль: " +modern + base.ToString();

        }



    }
}
