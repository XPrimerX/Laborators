using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_1
{
    class herbivore_animals : Animals
    {
        public herbivore_animals(string name, int age, double weight, bool iswild, Predatory_animal info) : base(name, age, weight, false, info)
        {

        }
        public herbivore_animals() { }
        public override bool IsDangerous()
        {
            if (Weight > 100 && Age > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
