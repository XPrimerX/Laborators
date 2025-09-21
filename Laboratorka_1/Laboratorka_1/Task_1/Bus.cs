using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_1
{
    public class Bus
    {

        public int nomer { get; set; }
        private string? pid;
        private float time;
        private string? punkt;
        public Bus(int nomer, string pID, float time, string punkt)
        {
            this.nomer = nomer;
            pid = pID;
            this.time = time;
            this.punkt = punkt;
        }
        public Bus() { }
        public string Pid
        {

            get { return pid; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();
                

                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    pid = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public float Time
        {
            get { return time; }
            set
            {
                if (value >= 0) time = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public string Punkt
        {
            get { return punkt; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();
                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    punkt = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return $"Номер автобусу: {nomer}, Пункт призначення: {Punkt}";
        }
    }
}

