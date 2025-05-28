using Modul_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modul_3.Clasi
{
    class Director :Iresume
    {
        private string? pi;
        private int age;
        public int money;
        public int age_work;
        public string? posada;
        public DateTime date;
        public Director(string? pi, int age, int money, int age_work, string? posada, DateTime date)
        {
            this.pi = pi;
            this.age = age;
            this.money = money;
            this.age_work = age_work;
            this.posada = posada;
            this.date = date;
        }
        public Director() { date = new DateTime(2000, 1, 1); }
        public string PI
        {
            get { return pi == null ? "No pi" : pi; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]{2,}$")) pi = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 100) age = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Money
        {
            get { return money; }
            set
            {
                if (value >= 8000 && value <= 50000) money = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Age_work
        {
            get { return age_work; }
            set
            {
                if (value >= 0 && value <= 70) age_work = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Posada
        {
            get { return posada == null ? "No posada" : posada; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]{2,}$")) posada = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                int age = DateTime.Now.Year - value.Year;
                if (age > 120 || age < 0) throw new ArgumentOutOfRangeException();
                date = value;
            }
        }
        public static void SetDirector(Director d)
        {
            Criteria_for_otbora.SetDirector(d);
        }
        public override string ToString()
        {
            return "\nПризвище та Імя: " + PI +
                "\nВік: " + Age +
                "\nДата народження: " + Date +
                "\nЗП яка потрібна:" + Money +
                "\nСтаж роботи який потрібен:" + Age_work +
                "\nПосада яка потрібна:" + Posada;
                
        }

    }
}
