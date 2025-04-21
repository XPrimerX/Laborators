using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorka_5
{
    class Person
    {
        private string firstName;
        private string lastName;
        private System.DateTime date;

        //Конструктор з трьома параметрами
        public Person(string _firstName, string _lastName, System.DateTime date)
        {
            firstName = _firstName;
            lastName = _lastName;
            this.date = date;
        }
        //Конструктор без параметрів
        public Person()
        {
            firstName = "FirstName";
            lastName = "lastName";
            date = new DateTime(2000, 1, 1);
        }
        //Конструктори з методами get і set
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < 200) firstName = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 200) lastName = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public DateTime Birthday
        {
            get { return date; }
            set
            {
                int age = DateTime.Now.Year - value.Year;
                if (age > 120 || age < 0) date = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int BirthYear
        {
            get { return date.Year; }
            set
            {
                int age = DateTime.Now.Year - value;
                if (age > 120 || age < 0) date = new DateTime(value, date.Month, date.Day);
                else throw new ArgumentOutOfRangeException();
               
            }
        }
        public override string ToString()
        {
            return "\nІм'я: " + firstName + "\nФамілія: " + lastName + "\nДата народження: " + date;
        }
        public string ToShortString()
        {
            return "\nІм'я: " + firstName + "\nФамілія: " + lastName;
        }


    }

}
