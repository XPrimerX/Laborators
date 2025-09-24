using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_6.Task_1
{
    public abstract class Animals
    {
        public string? name;
        public int age;
        public double weight;
        public  bool IsWild { get; set; }
        public Predatory_animal info { get; set; }
        public Animals(string name, int age, double weight, bool iswild, Predatory_animal info)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            IsWild = iswild;
            this.info = info;
        }
        public Animals() { }
        public string Name
        {
            get { return (name == null) ? "No Name" : name; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ]$")) name = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 60) age = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else weight = value;
            }
        }
        //замінює значення двох властивостей об’єкта
        public virtual void ReplaceFields(string newName, int newAge, double newweight)
        {
            name = newName;
            age = newAge;
            weight = newweight;
        }
        public abstract bool IsDangerous();

        public override string ToString()
        {
            return "\nНазва: " + name + "\nВік: " + age + "\nВага: " + weight + "кг" + "\nХижак " + IsWild + info;
        }
        public override bool Equals(object obj)
        {
            if (obj is Wild_animals)  { return ToString().Equals(((Wild_animals)obj).ToString()); }
            else if (obj is herbivore_animals) { return ToString().Equals(((herbivore_animals)obj).ToString()); }
            return false;
        }
        public override int GetHashCode() { return ToString().GetHashCode(); }
    }
}
