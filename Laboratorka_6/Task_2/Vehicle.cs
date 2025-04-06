using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_6.Task_2
{
   abstract class Vehicle
    {
        public int people;
        public float speed;
        public Vehicle(int people, float speed)
        {
            this.people = people;
            this.speed = speed;
        }
        public Vehicle()
        {
            people = 0;
            speed = 0;
        }
        public int People
        {
            get { return people; }
            set
            {
                if (value >= 0) people = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public float Speed
        {
            get { return speed; }
            set
            {
                if (speed >= 0) speed = value;
                else throw new ArgumentOutOfRangeException();
            }

        }
        public override string ToString()
        {
            return "\nШвидкість : "+ speed+"\nКількість людей: " + people;
        }


    }
}
