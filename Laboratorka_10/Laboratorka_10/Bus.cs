using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Laboratorka_10
{
    [Serializable]
    public class Bus
    {
        public int nomer {  get; set; }
        private string? PID;
        private float Time;
        private string? punkt;
        public Bus(int nomer, string pID, float time, string punkt)
        {
            this.nomer = nomer;
            PID = pID;
            Time = time;
            this.punkt = punkt;
        }
        public Bus() { }
        public string pid
        {
            get { return (PID == null) ? "No PID" : PID; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) PID = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public float time
        {
            get { return Time; }
            set 
            { 
                if(value>0) Time = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Punkt
        {
            get { return (punkt == null) ? "No punkt" : punkt; }
            set
            {
                if (Regex.IsMatch(value, @"^[A-Za-zА-Яа-яЇїІіЄєҐґ\s'-]+$")) punkt = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return $"Номер автобусу: {nomer}, Пункт призначення: {Punkt}";
        }
    }
}
