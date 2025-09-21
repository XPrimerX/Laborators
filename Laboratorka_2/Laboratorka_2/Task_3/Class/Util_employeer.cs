using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_2.Task_3.Class
{
    public class Util_employeer
    {
        private static Random rnd = new Random();

        private static string[] firstNames = { "Іван", "Володимир", "Олег", "Анна", "Марія", "Сергій", "Микола" };
        private static string[] lastNames = { "Петренко", "Коваль", "Гончар", "Сидоренко", "Шевченко", "Іваненко", "Бондаренко" };
        private static string[] positions = { "Worker", "Manager", "President" };
        private static string[] educationLevels = { "Higher", "Secondary", "Master" };
        private static DateTime RandomBirthDate()
        {
            int year = rnd.Next(1960, 2005);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
            return new DateTime(year, month, day);
        }
        public static Employer GenerateEmployer()
        {
            string firstName = firstNames[rnd.Next(firstNames.Length)];
            string lastName = lastNames[rnd.Next(lastNames.Length)];
            DateTime birthDate = RandomBirthDate();
            string education = educationLevels[rnd.Next(educationLevels.Length)];
            int experience = rnd.Next(0, 31); 
            float salary = rnd.Next(300, 5000); 
            string position = positions[rnd.Next(positions.Length)];

           
            return position switch
            {
                "Worker" => new Worker(firstName, lastName, birthDate, education, experience, salary, position),
                "Manager" => new Manager(firstName, lastName, birthDate, education, experience, salary, position),
                "President" => new President(firstName, lastName, birthDate, education, experience, salary, position),
                _ => new Worker(firstName, lastName, birthDate, education, experience, salary, "Worker"),
            };
        }
        public static List<Employer> GenerateEmployers(int count)
        {
            List<Employer> list = new List<Employer>();
            for (int i = 0; i < count; i++)
                list.Add(GenerateEmployer());
            return list;
        }
    }
}
