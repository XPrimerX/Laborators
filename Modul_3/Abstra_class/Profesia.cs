using Modul_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Modul_3.Abstra_class
{
   abstract class Profesia : Iresume
    {
        private string? pi;
        private int age;
        public int adress_apartament { get; set; }
         public int adress_bilding { get; set; }
        private string? street;
        private string? email;
        private string? phone;
        private int age_work;
        private string? family_stan;
        private int money;
        private string? posada;
        public DateTime date;
        public Profesia(string? pi, int age, int adress_bilding, int adress_apartament, string? street, string? email, string? phone, int age_work, string? family_stan, int money,string posada, DateTime date)
       {
            this.pi = pi;
            this.age = age;
            this.adress_bilding =adress_bilding;
            this.adress_apartament = adress_apartament;
            this.street = street;
            this.email = email;
            this.phone = phone;
            this.age_work = age_work;
            this.family_stan = family_stan;
            this.money = money;
            this.posada = posada;
            this.date = date;
       }
        public Profesia() { }
        public string PI
        {
            get { return pi == null ? "No pi" : pi; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]{2,}$")) pi = value;
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
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 100) age = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Street
        {
            get { return adress_bilding == 0 || adress_apartament == 0 || street == null ? "No adress" : street; }
            set
            {
                if (Regex.IsMatch(value, @"^[А-Яа-яЇїІіЄєҐґA-Za-z\s'-]{3,}$")) street = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Email
        {
            get { return email == null ? "No email" : email; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@gmail\.com$")) email = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Phone
        {
            get { return phone == null ? "No phone" : phone; }
            set
            {
                if (Regex.IsMatch(value, @"^\+380\d{9}$")) phone = value;
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
        public string Family_stan
        {
            get { return family_stan == null ? "No family_stan" : family_stan; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]{2,}$")) family_stan = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Money
        {
            get { return money; }
            set
            {
                if (value >=8000  && value <= 50000) money = value;
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
        public override string ToString()
        {
            return "\nПризвище та Імя: " + PI + 
                "\nВік: " + Age +
                "\nДата народження: " + Date.ToShortDateString() +
                "\nАдрес проживання: " + Street +" буд:"+adress_bilding +" квартира:"+ adress_apartament+
                "\nemail:" + Email+ 
                "\nтелефон:" + Phone + 
                "\nСтаж роботи:" + Age_work + " На посаді:"+ Posada+
                "\nСімейний стан:" + Family_stan + 
                "\nЗП:" + Money;
        }
    }
}
