using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_1
{
    public class Predatory_animal 
    {
        public string? Location;
        public int Population;
        public double ChangeRate;

        public Predatory_animal() { }
        public Predatory_animal(string location, int population, double changeRate)
        {
            Location = location;
            Population = population;
            ChangeRate = changeRate;
        
        }
        public double changeRate
        {
            get { return ChangeRate; } 
            set {
                if (value >= 0) ChangeRate = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string location
        {
            get { return (Location == null) ? "невідомо" : Location; }
            set {
                if (value.Length < 30) Location = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int population
        {
            get { return (Population); }
            set
            {
                if (value >= 0) Population = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public bool IsPopulation()
        {
            return Population > 50 && ChangeRate >= 1.0;
        }
        public override string ToString()
        {
            return "\nМісце: " + Location + "\nПопуляція: " + Population + "\nКоефіцієнт зміни: " + ChangeRate;
        }
        public override bool Equals(object obj)
        {
            if (obj is Predatory_animal) { return ToString().Equals(((Predatory_animal)obj).ToString()); }
            return false;
        }
        public override int GetHashCode() { return ToString().GetHashCode(); }


    }
}
