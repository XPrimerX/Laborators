using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_4
{
    public class Speak
    {
        public string name;
        public string LanguageFrom { get; set; } 
        public string LanguageTo { get; set; }
        public Dictionary<string, List<string>> Words { get; set; } = new();
        public Speak(string name, Dictionary<string, List<string>> Words)
        {
           this.name = name;
           this.Words = Words;
        }
        public Speak() { }
        public string Name
        {
            get { return name; }
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
