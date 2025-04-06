using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_1
{
    public class Predatory_animal : Wild_animals
    {
        public string Location { get; set; }
        public int Population { get; set; }
        public double ChangeRate { get; set; }

        public Predatory_animal(string name, int age, double weight,string location, int population, double changeRate) : base(name, age,weight)
        {
            Location = location;
            Population = population;
            ChangeRate = changeRate;
        }
        public bool IsPopulation()
        {
            return Population > 50 && ChangeRate >= 1.0;
        }
        public override void ReplaceFields(string newName, int newAge, double newweight)
        {
            base.ReplaceFields(newName, newAge, newweight);
        }
        public override string ToString()
        {
            return base.ToString() + "\nМісце: " + Location + "\nПопуляція: " + Population + "\nКоефіцієнт зміни: " + ChangeRate;
        }
        public override bool Equals(object obj)
        {
            if (obj is Predatory_animal) { return ToString().Equals(((Predatory_animal)obj).ToString()); }
            return false;
        }
        public override int GetHashCode() { return ToString().GetHashCode(); }


    }
}
