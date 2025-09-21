using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratorka_2.Task_2
{
    public class Phone
    {
        private string? name;
        private string? firms;
        private float price;
        public DateTime Date { get; set; }
        public Phone() { }

        public Phone(string? name, string? firms, float price, DateTime date)
        {
            this.name = name;
            this.firms = firms;
            this.price = price;
            Date = date;
        }
        public string Name
        {

            get { return name ?? "No name"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    name = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string Firms
        {

            get { return firms ?? "No firms"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    firms = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public float Price
        {
            get { return price; }
            set
            {

                if (value > 0)
                    price = value;
                else
                    throw new ArgumentOutOfRangeException();

            }
        }
        public override string ToString()
        {
            return $"назва телефону:{Name} виробник:{Firms} ціна:{Price}$ дата випуску:{Date.ToShortDateString()}";
        }
    }
}
