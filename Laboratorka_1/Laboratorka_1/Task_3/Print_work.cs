using Laboratorka_1.Task_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_3
{
    public class Print_work:IPrint
    {
        public int pages;
        private string? pid;
        private int priority;

        public DateTime Time { get; set; }
        public Print_work(int pages, string pid, DateTime time, int priority)
        {
            this.pages = pages;
            this.pid = pid;
            Time = time;
            this.priority = priority;
        }
        public Print_work() { }
        public string PID
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

        public int Pages
        {
            get { return pages; }
            set
            {
                if (value >= 0) pages = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Priority
        {
            get { return priority; }
            set
            {
                if (value > 0 && value<4) priority = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
    }
}
