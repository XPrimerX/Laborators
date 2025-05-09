using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laboratorka_8.Task_2
{
    public class Valisa
    {
        public string? Color;
        public string? Firma;
        public double Weight;
        public double Obem;
        public List<Element_do_Valisi> Vmist { get; set; }
        public Valisa(string color, string firma, double weight, double obem)
        {
            Color = color;
            Firma = firma;
            Weight = weight;
            Obem = obem;
            Vmist = new List<Element_do_Valisi>();
        }
        public Valisa() { }
        public string color
        {
            get { return Color == null ? "No Color" : Color; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ]+$")) Color = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string firma
        {
            get { return Firma == null ? "No Firma" : Firma; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ]+$")) Firma = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double weight
        {
            get { return Weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else Weight = value;
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

       
        public double Total_Obiem()
        {
            double total = 0;
            foreach(var element in Vmist)
            {
                total += element.obem;
            }
            return total;
        }
        public void DodatyObiekt(Element_do_Valisi obiekt)
        {
            if (Total_Obiem() + obiekt.obem > Obem)
            {
                throw new InvalidOperationException($"Неможливо додати '{obiekt.name}': перевищено об’єм валізи!");
            }

            Vmist.Add(obiekt);
            Console.WriteLine($"Об’єкт '{obiekt.name}' успішно додано.");
        }
        public override string ToString()
        {
            return "\nКолір: " + Color + "\nФірма: " + Firma + "\nВага: " + Weight + "кг" + "\nОб'єм: " + Obem + "\nВміст: " + string.Join(", ", Vmist);
        }

    }
}
