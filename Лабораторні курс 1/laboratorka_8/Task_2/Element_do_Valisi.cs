using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laboratorka_8.Task_2
{
   public class Element_do_Valisi
    {
        private string? Name;
        private double Obem;

        public Element_do_Valisi(string name, double obem)
        {
            this.name = name;
            this.obem = obem;
        }

        public string name
        {
            get { return Name == null ? "No Name" : Name; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ]+$")) Name = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double obem
        {
            get { return Obem; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else Obem = value;
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Obem} л)";
        }
    }
}
