using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb_7.Task_1
{
    class Person_from_lb5 : IComparable<Person_from_lb5>, ICloneable
    {
        private string firstName;
        private string lastName;
        private DateTime date;

        //Конструктор з трьома параметрами
        public Person_from_lb5(string _firstName, string _lastName, DateTime date)
        {
            firstName = _firstName;
            lastName = _lastName;
            this.date = date;
        }
        //Конструктор без параметрів
        public Person_from_lb5()
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
                if (age > 120 || age < 0) throw new ArgumentOutOfRangeException();
                date = value;
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

        //Реалізація IComparable
        public int CompareTo(Person_from_lb5 other)
        {
            if (other == null) return 1;
            return Birthday.Year.CompareTo(other.Birthday.Year); //Порівнює за роком
        }
        // Реалізація ICloneable
        public object Clone()
        {
            return new Person_from_lb5(firstName, lastName, date);
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

