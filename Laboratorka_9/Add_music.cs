using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratorka_9
{
    internal class Add_music
    {
        private string name_music;
        private string name_songer;
        private string komposito;
        private int year;
        private string text;
        private List<string> mnogo_kompositorov = new List<string>();


        public Add_music(string name_music, string name_songer, string komposito, int year, string text)
        {
            this.name_music = name_music;
            this.name_songer = name_songer;
            this.komposito = komposito;
            this.year = year;
            this.text = text;
            mnogo_kompositorov = new List<string>();
        }
        public Add_music() { }
        public string Name_music
        {
            get { return (name_music == null) ? "No Name music" : name_music; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) name_music = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Name_songer
        {
            get { return (name_songer == null) ? "No Name songer" : name_songer; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) name_songer = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Komposito
        {
            get { return (komposito == null) ? "No Name komposito" : komposito; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) komposito = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (value > 1800 && value <= DateTime.Now.Year) year = value; 
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Text
        {
            get { return (text == null) ? "No text" : text; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) text = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public List<string> Mnogo_kompositorov
        {
            get { return mnogo_kompositorov; }
        }
        public override string ToString()
        {
            return $"Назва: {Name_music}, Автор: {Name_songer}, Композитор: {Komposito}, Рік: {Year}, Виконавці: {string.Join(", ", Mnogo_kompositorov)}, Текст: {Text}";
        }
    }
}
