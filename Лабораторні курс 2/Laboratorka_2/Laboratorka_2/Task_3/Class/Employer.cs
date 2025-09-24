using Laboratorka_2.Task_3.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorka_2.Task_3.Class
{
    public class Employer: IPasport, IJob
    {
        private string? firstname;
        private string? lastname;
        private string? levelofeducation;
        private int opit;
        private float salary;
        private string? position;
        public DateTime BirthDate { get; set; }

        public Employer() { }
        public Employer(string firstname, string lastname, string levelofeducation, int opit, float salary, string position, DateTime birthDate)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.levelofeducation = levelofeducation;
            this.opit = opit;
            this.salary = salary;
            this.position = position;
            BirthDate = birthDate;
        }
        public string FirstName
        {

            get { return firstname ?? "No firstname"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    firstname = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string LastName
        {

            get { return lastname ?? "No lastname"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    lastname = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string LevelofEducation
        {

            get { return levelofeducation ?? "No levelofeducation"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    levelofeducation = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int Opit
        {
            get { return opit; }
            set
            {

                if (value >= 0)
                    opit = value;
                else
                    throw new ArgumentOutOfRangeException();

            }
        }
        public float Salary
        {
            get { return salary; }
            set
            {

                if (value >= 200)
                    salary = value;
                else
                    throw new ArgumentOutOfRangeException();

            }
        }
        public string Position
        {

            get { return position ?? "No position"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    position = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return $"Ім'я: {firstname}, Прізвище: {lastname}, " +
                   $"Освіта: {levelofeducation}, Стаж: {opit} років, " +
                   $"Посада: {position}, Зарплата: {salary} $, " +
                   $"Дата народження: {BirthDate:yyyy-MM-dd}";
        }
    }
}
