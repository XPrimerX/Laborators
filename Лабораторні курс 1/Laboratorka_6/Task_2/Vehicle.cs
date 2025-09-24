using Laboratorka_6.Task_2.Interface_and_Utilits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_6.Task_2
{
   abstract class Vehicle : IWeightable
    {
        public int people;
        public float speed;
        private float weight;
        public Vehicle(int people, float speed, float weight)
        {
            this.people = people;
            this.speed = speed;
            this.weight = weight;
        }
        public Vehicle()
        {

        }
        public int People
        {
            get { return people; }
            set
            {
                if (value >= 1) people = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public float Speed
        {
            get { return speed; }
            set
            {
                if (value >= 0) speed = value;
                else throw new ArgumentOutOfRangeException();
            }

        }
        public float Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else weight = value;
            }
        }
        public override string ToString()
        {
            return "\nШвидкість : "+ speed+"\nКількість людей: " + people + "\nВага: " + Weight;
        }


    }
}
