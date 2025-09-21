using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_2.Task_3.Class
{
    public class Company
    {
        private string? name;
        public List<Employer> Employers { get; set; } = new List<Employer>();

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
    }
}
